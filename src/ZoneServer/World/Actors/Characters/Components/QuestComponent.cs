using System;
using System.Collections.Generic;
using System.Linq;
using Melia.Shared.ObjectProperties;
using Melia.Shared.Scripting;
using Melia.Shared.Game.Const;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Yggdrasil.Scheduling;
using Yggdrasil.Util;

namespace Melia.Zone.World.Actors.Characters.Components
{
	/// <summary>
	/// A character's quest manager.
	/// </summary>
	/// <remarks>
	/// Our current quest system is custom-made, as the system the game
	/// comes with is not very flexible. Using our own allows us to freely
	/// create custom quests, add features that wouldn't be available
	/// otherwise, and generally be independent of the game's ideas of
	/// quests. The downside is that our system might require some
	/// rethinking when trying to replicate the game's quests.
	/// </remarks>
	public class QuestComponent : CharacterComponent, IUpdateable
	{
		private readonly static TimeSpan AutoReceiveDelay = TimeSpan.FromMinutes(1);

		private readonly object _syncLock = new object();
		private readonly List<Quest> _quests = new List<Quest>();
		private TimeSpan _autoReceiveDelay = AutoReceiveDelay;

		/// <summary>
		/// Creates new instance for character.
		/// </summary>
		/// <param name="character"></param>
		public QuestComponent(Character character)
			: base(character)
		{
		}

		/// <summary>
		/// Adds quest without informing the client.
		/// </summary>
		/// <remarks>
		/// This is primarily used while the character and its quests are
		/// loaded from the database.
		/// </remarks>
		/// <param name="quest"></param>
		public void AddSilent(Quest quest)
		{
			lock (_syncLock)
				_quests.Add(quest);
		}

		/// <summary>
		/// Gets quest by id and returns it via out, returns false if the
		/// quest didn't exist.
		/// </summary>
		/// <param name="questObjectId"></param>
		/// <param name="quest"></param>
		/// <returns></returns>
		public bool TryGet(long questObjectId, out Quest quest)
		{
			lock (_syncLock)
			{
				quest = _quests.Find(a => a.ObjectId == questObjectId);
				return quest != null;
			}
		}

		/// <summary>
		/// Gets quest by id and returns it via out, returns false if the
		/// quest didn't exist.
		/// </summary>
		/// <param name="questId"></param>
		/// <param name="quest"></param>
		/// <returns></returns>
		public bool TryGetById(int questId, out Quest quest)
		{
			lock (_syncLock)
			{
				quest = _quests.Find(a => a.Data.Id == questId);
				return quest != null;
			}
		}

		/// <summary>
		/// Returns a list of all active quests.
		/// </summary>
		/// <returns></returns>
		public Quest[] GetInProgress()
		{
			lock (_syncLock)
				return _quests.Where(a => a.InProgress).ToArray();
		}

		/// <summary>
		/// Returns a list with all of the character's quests.
		/// </summary>
		/// <returns></returns>
		public Quest[] GetList()
		{
			lock (_syncLock)
				return _quests.ToArray();
		}

		/// <summary>
		/// Calls OnStart on the quest's objectives to go through the
		/// potential initial checks for whether the objective was
		/// possibly already completed.
		/// </summary>
		/// <param name="quest"></param>
		private void InitialChecks(Quest quest)
		{
			var checkedTypes = new HashSet<Type>();

			foreach (var objective in quest.Data.Objectives)
			{
				// Check every objective type only once, as they're designed
				// to check all of the quest's objectives at once.
				var type = objective.GetType();
				if (checkedTypes.Contains(type))
					continue;

				objective.OnStart(this.Character, quest);
				checkedTypes.Add(type);
			}
		}

		/// <summary>
		/// Iterates over the quests' objectives, runs the given function
		/// over all objectives with the given type, and updates the quest
		/// if any progresses changed.
		/// </summary>
		/// <typeparam name="TObjective"></typeparam>
		/// <param name="updater"></param>
		public void UpdateObjectives<TObjective>(QuestObjectivesUpdateFunc<TObjective> updater) where TObjective : QuestObjective
		{
			lock (_syncLock)
			{
				for (var i = 0; i < _quests.Count; i++)
				{
					var quest = _quests[i];
					if (quest.Status != QuestStatus.Progress)
						continue;

					quest.UpdateObjectives(updater);

					if (quest.ChangesOnLastUpdate)
					{
						quest.UpdateUnlock();
						this.UpdateClient_UpdateQuest(quest);
					}
				}
			}
		}

		/// <summary>
		/// Iterates over the quests' modifiers, runs the given function
		/// over all modifiers with the given type, and updates the quest
		/// if any progresses changed.
		/// </summary>
		/// <typeparam name="TModifier"></typeparam>
		/// <param name="updater"></param>
		public void UpdateModifiers<TModifier>(QuestModifiersUpdateFunc<TModifier> updater) where TModifier : QuestModifier
		{
			lock (_syncLock)
			{
				for (var i = 0; i < _quests.Count; i++)
				{
					var quest = _quests[i];
					if (quest.Status != QuestStatus.Progress)
						continue;

					quest.UpdateModifiers(updater);

					if (quest.ChangesOnLastUpdate)
					{
						quest.UpdateUnlock();
					}
				}
			}
		}

		/// <summary>
		/// Starts quest for the character, returns false if the quest
		/// couldn't be started.
		/// </summary>
		/// <param name="questId"></param>
		/// <returns></returns>
		public void Start(string questId)
		{
			if (!ZoneServer.Instance.Data.QuestDb.TryFind(questId, out var questData))
				throw new ArgumentException($"Unknown quest '{questId}'.");
			this.Start(questData.Id, TimeSpan.Zero);
		}

		/// <summary>
		/// Starts quest for the character, returns false if the quest
		/// couldn't be started.
		/// </summary>
		/// <param name="questId"></param>
		/// <returns></returns>
		public void Start(int questId)
			=> this.Start(questId, TimeSpan.Zero);

		/// <summary>
		/// Adds quest and starts it after the given delay.
		/// </summary>
		/// <param name="questId"></param>
		/// <param name="delay"></param>
		/// <returns></returns>
		public void Start(int questId, TimeSpan delay)
		{
			delay = Math2.Max(TimeSpan.Zero, delay);

			var quest = Quest.Create(questId);

			if (delay == TimeSpan.Zero)
			{
				this.Start(quest);
				this.AddSilent(quest);
			}
			else
			{
				quest.StartTime = DateTime.Now.Add(delay);
				this.AddSilent(quest);
			}
		}

		/// <summary>
		/// Starts the given quest, adding it to the character's quest log.
		/// </summary>
		/// <param name="quest"></param>
		/// <returns></returns>
		private void Start(Quest quest)
		{
			this.InitialChecks(quest);

			quest.Status = QuestStatus.Progress;
			quest.UpdateUnlock();

			if (quest.StartTime == DateTime.MinValue)
				quest.StartTime = DateTime.Now;

			if (QuestScript.TryGet(quest.Data.Id, out var questScript))
				questScript.OnStart(this.Character, quest);

			this.UpdateClient_AddQuest(quest);
		}

		/// <summary>
		/// Returns true if a quest with the given id is currently in
		/// progress and the objective with the given identifier is
		/// unlocked, but hasn't been completed yet.
		/// </summary>
		/// <param name="questId"></param>
		/// <param name="objectiveIdent"></param>
		/// <returns></returns>
		public bool IsActive(int questId, string objectiveIdent)
		{
			lock (_syncLock)
			{
				for (var i = 0; i < _quests.Count; i++)
				{
					var quest = _quests[i];
					if (!quest.InProgress || quest.Data.Id != questId)
						continue;

					if (!quest.TryGetProgress(objectiveIdent, out var progress))
						continue;

					if (progress.Unlocked && !progress.Done)
						return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Returns true if a quest with the given id is currently active,
		/// meaning that it was started, but not completed yet, even if
		/// all objectives were completed already.
		/// </summary>
		/// <param name="questId"></param>
		/// <returns></returns>
		public bool IsActive(int questId)
		{
			lock (_syncLock)
			{
				for (var i = 0; i < _quests.Count; i++)
				{
					var quest = _quests[i];
					if (quest.InProgress && quest.Data.Id == questId)
						return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Check if all prerequisites are met and the quest isn't started.
		/// </summary>
		/// <param name="questId"></param>
		/// <returns></returns>
		public bool IsPossible(int questId)
		{
			// Can't start a quest if a track is active.
			if (this.Character.Tracks.ActiveTrack != null)
				return false;

			lock (_syncLock)
			{
				for (var i = 0; i < _quests.Count; i++)
				{
					var quest = _quests[i];
					if (quest.Data.Id != questId)
						continue;
					return quest.IsPossible;
				}
				if (QuestScript.TryGet(questId, out var questScript))
				{
					for (var j = 0; j < questScript.Data.Prerequisites.Count; j++)
					{
						var prerequisite = questScript.Data.Prerequisites[j];
						if (!prerequisite.Met(this.Character))
							return false;
					}
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Returns true if the character has the quest, is slated to
		/// receive it soon, or has completed it in the past.
		/// </summary>
		/// <param name="questId"></param>
		/// <returns></returns>
		public bool Has(int questId)
		{
			lock (_syncLock)
			{
				for (var i = 0; i < _quests.Count; i++)
				{
					var quest = _quests[i];
					if (quest.Data.Id != questId)
						continue;

					if (quest.Status > QuestStatus.Possible)
						return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Returns true if the character has ever completed the quest
		/// before.
		/// </summary>
		/// <param name="questId"></param>
		/// <returns></returns>
		public bool HasCompleted(int questId)
		{
			lock (_syncLock)
			{
				for (var i = 0; i < _quests.Count; i++)
				{
					var quest = _quests[i];
					if (quest.Data.Id != questId)
						continue;

					if (quest.Status == QuestStatus.Complete)
						return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Completes the objective on all quests with the given id.
		/// </summary>
		/// <param name="questId"></param>
		/// <param name="objectiveIdent"></param>
		public void CompleteObjective(int questId, string objectiveIdent)
		{
			lock (_syncLock)
			{
				for (var i = 0; i < _quests.Count; i++)
				{
					var quest = _quests[i];
					if (!quest.InProgress || quest.Data.Id != questId)
						continue;

					if (!quest.TryGetProgress(objectiveIdent, out var progress))
						continue;

					if (!progress.Done)
					{
						progress.SetDone();
						quest.UpdateUnlock();
						UpdateQuestProgress(questId, progress.Objective.Id);
						this.UpdateClient_UpdateQuest(quest);
						continue;
					}
				}
			}
		}

		/// <summary>
		/// Completes all quests with the given id and gives the rewards
		/// to the character.
		/// </summary>
		/// <param name="questId"></param>
		public void Complete(int questId)
		{
			lock (_syncLock)
			{
				for (var i = 0; i < _quests.Count; i++)
				{
					var quest = _quests[i];
					if (quest.Data.Id != questId || !quest.InProgress)
						continue;

					quest.CompleteObjectives();

					this.Complete(quest);
				}
			}
		}

		/// <summary>
		/// Completes quest and gives rewards to character.
		/// </summary>
		/// <param name="quest"></param>
		public void Complete(Quest quest)
		{
			quest.Status = QuestStatus.Complete;
			quest.CompleteTime = DateTime.Now;
			quest.CompleteObjectives();

			if (QuestScript.TryGet(quest.Data.Id, out var questScript))
				questScript.OnComplete(this.Character, quest);

			this.GiveRewards(quest);

			this.UpdateClient_RemoveQuest(quest);
			this.UpdateClient_CompleteQuest(quest);
		}

		/// <summary>
		/// Removes quest from quest log.
		/// </summary>
		/// <param name="quest"></param>
		public void Cancel(Quest quest)
		{
			quest.Status = QuestStatus.Abandoned;

			if (QuestScript.TryGet(quest.Data.Id, out var questScript))
				questScript.OnCancel(this.Character, quest);

			this.UpdateClient_RemoveQuest(quest);
		}

		/// <summary>
		/// Gives quest's rewards to character.
		/// </summary>
		/// <param name="quest"></param>
		private void GiveRewards(Quest quest)
		{
			foreach (var reward in quest.Data.Rewards)
				reward.Give(this.Character);
		}

		/// <summary>
		/// Abandon a quest
		/// </summary>
		/// <param name="questId"></param>
		/// <returns></returns>
		public bool Abandon(int questId)
		{
			if (!this.Has(questId) || !this.TryGet(questId, out var quest) || !quest.InProgress)
				return false;

			this.Cancel(quest);

			return true;
		}

		/// <summary>
		/// Restart a quest
		/// </summary>
		/// <param name="questId"></param>
		/// <returns></returns>
		public bool Restart(int questId, QuestStatus status = QuestStatus.Restarted)
		{
			if (!this.IsPossible(questId))
				return false;

			if (!this.TryGet(questId, out var quest))
				quest = Quest.Create(questId);
			quest.Status = status;
			this.UpdateQuestStatus(questId, quest.Status);

			if (QuestScript.TryGet(quest.Data.Id, out var questScript))
				questScript.OnStart(this.Character, quest);

			return true;
		}

		public void UpdateQuestStatus(int questId, QuestStatus status)
		{
			lock (_syncLock)
			{
				for (var i = 0; i < _quests.Count; i++)
				{
					var quest = _quests[i];
					if (quest.Data.Id != questId)
						continue;

					quest.Status = status;

					this.UpdateClient_UpdateQuest(quest);
					break;
				}
			}
		}

		/// <summary>
		/// Updates the quests that weren't started yet, starting them
		/// once their start time was reached.
		/// </summary>
		/// <param name="elapsed"></param>
		public void Update(TimeSpan elapsed)
		{
			var now = DateTime.Now;

			lock (_syncLock)
			{
				for (var i = 0; i < _quests.Count; i++)
				{
					var quest = _quests[i];
					if (quest.Status != QuestStatus.Possible)
						continue;

					if (quest.StartTime < now)
						this.Start(quest);
				}
			}

			// Check and start auto receive quests in regular intervals
			_autoReceiveDelay = Math2.Max(TimeSpan.Zero, _autoReceiveDelay - elapsed);
			if (_autoReceiveDelay == TimeSpan.Zero)
			{
				QuestScript.StartAutoReceiveQuests(this.Character);
				_autoReceiveDelay = AutoReceiveDelay;
			}
		}

		/// <summary>
		/// Sends a list of all quests to the client to update it.
		/// </summary>
		public void UpdateClient()
		{
			var quests = this.GetList();
			foreach (var quest in quests.Where(a => a.Status == QuestStatus.Progress))
			{
				var questTable = this.QuestToTable(quest);

				var lua = "Melia.Quests.Restore(" + questTable.Serialize() + ")";
				Send.ZC_EXEC_CLIENT_SCP(this.Character.Connection, lua);
			}
		}

		/// <summary>
		/// Adds the quest to the client's quest log.
		/// </summary>
		/// <param name="quest"></param>
		private void UpdateClient_AddQuest(Quest quest)
		{
			if (ZoneServer.Instance.Data.QuestDb.TryFind(quest.Data.Id, out var questData))
			{
				if (quest.QuestStaticData != null)
				{
					var main = this.Character.SessionObjects.Main;

					if (!string.IsNullOrWhiteSpace(quest.QuestStaticData.QStartZone)
						&& quest.QuestStaticData.QStartZone != main.Properties.GetString(PropertyName.QSTARTZONETYPE))
					{
						main.Properties.SetString(PropertyName.QSTARTZONETYPE, quest.QuestStaticData.QStartZone);
						Send.ZC_OBJECT_PROPERTY(this.Character, main, PropertyName.QSTARTZONETYPE);
					}
				}
				if (quest.SessionObjectStaticData != null)
				{
					var questSessionObject = this.Character.SessionObjects.GetOrCreate(quest.SessionObjectStaticData.Id);
					if (questSessionObject != null)
					{
						if (quest.SessionObjectStaticData.QuestData.InfoMaxCount != null)
							questSessionObject.Properties.SetFloat(PropertyName.QuestInfoValue1, 0f);
						Send.ZC_SESSION_OBJ_ADD(this.Character, questSessionObject, quest.QuestStaticData.Id);
					}
					UpdateClient_UpdateQuest(quest);
				}
				return;
			}

			var questTable = this.QuestToTable(quest);

			var table = new LuaTable();
			table.Insert("Op", "QuestAdd");
			table.Insert("Data", questTable);

			var lua = "Melia.Quests.Add(" + questTable.Serialize() + ")";
			Send.ZC_EXEC_CLIENT_SCP(this.Character.Connection, lua);

			//Log.Debug(lua);
		}

		/// <summary>
		/// Updates the quest objectives on the client.
		/// </summary>
		/// <param name="quest"></param>
		private void UpdateClient_UpdateQuest(Quest quest)
		{
			if (ZoneServer.Instance.Data.QuestDb.TryFind(quest.Data.Id, out var questData) && !string.IsNullOrEmpty(quest.QuestStaticData.QuestProperty))
			{
				var main = this.Character.SessionObjects.Main;

				if (!main.Properties.Has(quest.QuestStaticData.QuestProperty))
				{
					main.Properties.SetFloat(quest.QuestStaticData.QuestProperty, 1);
					Send.ZC_OBJECT_PROPERTY(this.Character, main, quest.QuestStaticData.QuestProperty);
				}
				main.Properties.SetFloat(quest.QuestStaticData.QuestProperty, (int)quest.Status);
				Send.ZC_OBJECT_PROPERTY(this.Character, main, quest.QuestStaticData.QuestProperty);
				return;
			}

			var objectivesTable = this.ObjectivesToTable(quest);

			var questTable = new LuaTable();
			questTable.Insert("ObjectId", "0x" + quest.ObjectId.ToString("X16"));
			questTable.Insert("Status", quest.Status.ToString());
			questTable.Insert("Done", quest.ObjectivesCompleted);
			questTable.Insert("Objectives", objectivesTable);

			var lua = "Melia.Quests.Update(" + questTable.Serialize() + ")";
			Send.ZC_EXEC_CLIENT_SCP(this.Character.Connection, lua);

			//Log.Debug(lua);
		}

		/// <summary>
		/// Removes the quest from the client's quest log.
		/// </summary>
		/// <param name="quest"></param>
		private void UpdateClient_RemoveQuest(Quest quest)
		{
			if (ZoneServer.Instance.Data.QuestDb.TryFind(quest.Data.Id, out var questData) && quest.SessionObjectStaticData != null)
			{
				this.Character.SessionObjects.Remove(quest.SessionObjectStaticData.Id);
				Send.ZC_SESSION_OBJ_REMOVE(this.Character, quest.SessionObjectStaticData.Id);
				return;
			}

			var lua = $"Melia.Quests.Remove('{quest.ObjectIdStr}')";
			Send.ZC_EXEC_CLIENT_SCP(this.Character.Connection, lua);
		}

		/// <summary>
		/// Notifies the client that the quest was completed.
		/// </summary>
		/// <param name="quest"></param>
		private void UpdateClient_CompleteQuest(Quest quest)
		{
			if (ZoneServer.Instance.Data.QuestDb.TryFind(quest.Data.Id, out var questData) && !string.IsNullOrEmpty(questData.QuestProperty))
			{
				var main = this.Character.SessionObjects.Main;
				var propertyName = questData.QuestProperty;

				main.Properties.SetFloat(propertyName, (float)QuestStatus.Complete);
				Send.ZC_OBJECT_PROPERTY(this.Character, main, propertyName);
				return;
			}

			var lua = $"Melia.Quests.Remove('{quest.ObjectIdStr}')";
			Send.ZC_EXEC_CLIENT_SCP(this.Character.Connection, lua);
		}

		/// <summary>
		/// Returns all information about the quest as a Lua table.
		/// </summary>
		/// <param name="quest"></param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException"></exception>
		private LuaTable QuestToTable(Quest quest)
		{
			var objectivesTable = this.ObjectivesToTable(quest);

			var rewardsTable = new LuaTable();
			foreach (var reward in quest.Data.Rewards)
			{
				var rewardTable = new LuaTable();
				rewardTable.Insert("Text", reward.ToString());
				rewardTable.Insert("Icon", reward.Icon);

				rewardsTable.Insert(rewardTable);
			}

			var questTable = new LuaTable();

			questTable.Insert("ObjectId", "0x" + quest.ObjectId.ToString("X16"));
			questTable.Insert("ClassId", quest.Data.Id);
			questTable.Insert("Name", quest.Data.Name);
			questTable.Insert("Description", quest.Data.Description);
			questTable.Insert("Level", quest.Data.Level);
			questTable.Insert("Status", quest.Status.ToString());
			questTable.Insert("Done", quest.ObjectivesCompleted);
			questTable.Insert("Cancelable", quest.Data.Cancelable);
			questTable.Insert("Objectives", objectivesTable);
			questTable.Insert("Rewards", rewardsTable);

			return questTable;
		}

		/// <summary>
		/// Returns information about the quests objectives and their
		/// progress as a Lua table.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException"></exception>
		private LuaTable ObjectivesToTable(Quest quest)
		{
			var objectivesTable = new LuaTable();
			foreach (var objective in quest.Data.Objectives)
			{
				if (!quest.TryGetProgress(objective.Ident, out var progress))
					throw new InvalidOperationException($"Missing progress for objective '{objective.Ident}'.");

				var objectiveTable = new LuaTable();
				objectiveTable.Insert("Text", objective.Text);
				objectiveTable.Insert("Unlocked", progress.Unlocked);
				objectiveTable.Insert("Done", progress.Done);
				objectiveTable.Insert("Count", progress.Count);
				objectiveTable.Insert("TargetCount", objective.TargetCount);

				objectivesTable.Insert(objectiveTable);
			}

			return objectivesTable;
		}

		/// <summary>
		/// Checks if the quest is completable
		/// </summary>
		/// <param name="questId"></param>
		/// <returns></returns>
		public bool IsCompletable(int questId)
		{
			lock (_syncLock)
			{
				for (var i = 0; i < _quests.Count; i++)
				{
					var quest = _quests[i];

					if (!quest.InProgress || quest.Data.Id != questId)
						continue;

					return quest.ObjectivesCompleted;
				}
			}

			return false;
		}

		public QuestStatus GetStatus(int questId)
		{
			lock (_syncLock)
			{
				for (var i = 0; i < _quests.Count; i++)
				{
					var quest = _quests[i];

					if (quest.Data.Id != questId)
						continue;

					return quest.Status;
				}
			}
			return QuestStatus.Possible;
		}

		/// <summary>
		/// Update quest progress
		/// </summary>
		/// <param name="questId"></param>
		/// <param name="objectiveId"></param>
		public void UpdateQuestProgress(int questId, int objectiveId)
		{
			if (this.TryGetById(questId, out var quest))
			{
				var character = this.Character;
				var progress = quest.Progresses[objectiveId];
				if (quest.QuestStaticData != null)
				{
					var mainSessionObject = character.SessionObjects.Get(SessionObjectId.Main);
					// In case quest doesn't exist, set it's state to started (1)
					if (!mainSessionObject.Properties.Has(quest.QuestStaticData.QuestProperty))
					{
						mainSessionObject.Properties.SetFloat(quest.QuestStaticData.QuestProperty, 1);
						Send.ZC_OBJECT_PROPERTY(character, mainSessionObject, quest.QuestStaticData.QuestProperty);
					}

					var questSessionObject = character.SessionObjects.GetOrCreate(quest.SessionObjectStaticData.Id);
					if (questSessionObject != null)
					{
						string propertyName;
						if (quest.Progresses[objectiveId].Objective is KillObjective)
							propertyName = $"KillMonster{objectiveId + 1}";
						else
							propertyName = $"QuestInfoValue{objectiveId + 1}";

						questSessionObject.Properties.SetFloat(propertyName, quest.ProgressValue(objectiveId));
						Send.ZC_OBJECT_PROPERTY(character, questSessionObject, propertyName);
						if (progress.Done)
						{
							var goalPropertyName = $"Goal{objectiveId + 1}";
							questSessionObject.Properties.SetFloat(goalPropertyName, 1);
							Send.ZC_OBJECT_PROPERTY(character, questSessionObject, goalPropertyName);
						}
					}
				}
				if (QuestScript.TryGet(quest.Data.Id, out var questScript))
					questScript.OnProgress(this.Character, quest, progress.Objective.Id, quest.ProgressValue(objectiveId));
				if (quest.IsCompletable)
				{
					quest.Status = QuestStatus.Success;
					questScript?.OnSuccess(this.Character, quest);
				}
			}
		}
	}
}
