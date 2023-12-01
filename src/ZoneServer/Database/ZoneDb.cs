using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Melia.Shared.Data.Database;
using Melia.Shared.Database;
using Melia.Shared.ObjectProperties;
using Melia.Shared.Tos.Const;
using Melia.Shared.Tos.Const.Web;
using Melia.Shared.Tos.Properties;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Scripting;
using Melia.Zone.Skills;
using Melia.Zone.World;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Characters.Components;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.World.Actors.Monsters;
using Melia.Zone.World.Groups;
using Melia.Zone.World.Houses;
using Melia.Zone.World.Items;
using Melia.Zone.World.Maps;
using Melia.Zone.World.Quests;
using MySqlConnector;
using Yggdrasil.Logging;
using Yggdrasil.Util;

namespace Melia.Zone.Database
{
	public class ZoneDb : MeliaDb
	{
		/// <summary>
		/// Saves account.
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public bool SaveAccount(Account account)
		{
			if (account == null)
				throw new ArgumentNullException("account");

			using (var conn = this.GetConnection())
			using (var cmd = new UpdateCommand("UPDATE `accounts` SET {0} WHERE `accountId` = @accountId", conn))
			{
				cmd.AddParameter("@accountId", account.Id);
				cmd.Set("settings", account.Settings.ToString());

				if (cmd.Execute() == 0)
					return false;
			}

			this.SaveVariables(account.Variables.Perm, "vars_accounts", "accountId", account.Id);
			this.SaveProperties("account_properties", "accountId", account.Id, account.Properties);
			this.SaveChatMacros(account);
			this.SaveRevealedMaps(account);
			this.SaveAssisters(account);

			return true;
		}

		/// <summary>
		/// Returns account with given name, or null if it doesn't exist.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public Account GetAccount(string name)
		{
			var account = new Account();

			using (var conn = this.GetConnection())
			using (var mc = new MySqlCommand("SELECT * FROM `accounts` WHERE `name` = @name", conn))
			{
				mc.Parameters.AddWithValue("@name", name);

				using (var reader = mc.ExecuteReader())
				{
					if (!reader.Read())
						return null;

					account.Id = reader.GetInt64("accountId");
					account.Name = reader.GetStringSafe("name");
					account.TeamName = reader.GetStringSafe("teamName");
					account.Authority = reader.GetInt32("authority");
					account.Type = (AccountType)reader.GetByte("type");
					account.Settings.Parse(reader.GetStringSafe("settings"));
					account.Medals = reader.GetInt32("medals");
					account.GiftMedals = reader.GetInt32("giftMedals");
					account.PremiumMedals = reader.GetInt32("premiumMedals");
				}
			}

			this.LoadProperties("account_properties", "accountId", account.Id, account.Properties);
			this.LoadVars(account.Variables.Perm, "vars_accounts", "accountId", account.Id);
			this.LoadChatMacros(account);
			this.LoadRevealedMaps(account);
			this.LoadAssisters(account);

			return account;
		}

		/// <summary>
		/// Returns given character, or null if it doesn't exist.
		/// </summary>
		/// <param name="characterId"></param>
		/// <returns></returns>
		public Character GetCharacter(long accountId, long characterId)
		{
			var character = new Character();
			//var stamina = 25000;

			// When switching maps, the client sends the character object
			// id to select the character, as it's the only information
			// it has. We'll need to adjust that id here to the get the
			// correct character. DatabaseId is ObjectId - Range.
			if (characterId > ObjectIdRanges.Characters)
				characterId -= ObjectIdRanges.Characters;

			using (var conn = this.GetConnection())
			using (var mc = new MySqlCommand("SELECT * FROM `characters` WHERE `accountId` = @accountId AND `characterId` = @characterId", conn))
			{
				mc.Parameters.AddWithValue("@accountId", accountId);
				mc.Parameters.AddWithValue("@characterId", characterId);

				using (var reader = mc.ExecuteReader())
				{
					if (!reader.Read())
						return null;

					character.DbId = reader.GetInt64("characterId");
					character.AccountDbId = accountId;
					character.Name = reader.GetStringSafe("name");
					character.TeamName = reader.GetStringSafe("teamName");
					character.JobId = (JobId)reader.GetInt16("job");
					character.Gender = (Gender)reader.GetByte("gender");
					character.Hair = reader.GetInt32("hair");
					character.MapId = reader.GetInt32("zone");
					character.Exp = reader.GetInt64("exp");
					character.MaxExp = reader.GetInt64("maxExp");
					character.TotalExp = reader.GetInt64("totalExp");

					// Something isn't quite right with the visibility
					// after login right now, because the client always
					// shows everything as visible, even when it's not.
					// So we'll default to everything being visible
					// for now, so the player can at least properly
					// disable the visibility while in-game.
					//character.VisibleEquip = (VisibleEquip)reader.GetInt32("equipVisibility");

					// We get the character's stamina from its data here
					// because this is not a PC property. Actually setting
					// it has to wait until we loaded the properties, however,
					// to get the accurate MaxStamina.
					//stamina = reader.GetInt32("stamina");

					var x = reader.GetFloat("x");
					var y = reader.GetFloat("y");
					var z = reader.GetFloat("z");
					var dir = reader.GetFloat("dir");
					character.Position = new Position(x, y, z);
					character.Direction = new Direction(dir);

					character.PartyId = reader.GetInt64("partyId");
					character.GuildId = reader.GetInt64("guildId");
				}
			}

			this.LoadCharacterItems(character);
			this.LoadCharacterWarehouseItems(character);
			this.LoadVars(character.Variables.Perm, "vars_characters", "characterId", character.DbId);
			this.LoadSessionObjects(character);
			this.LoadJobs(character);
			this.LoadSkills(character);
			this.LoadAbilities(character);
			this.LoadBuffs(character);
			this.LoadCooldowns(character);
			this.LoadQuests(character);
			this.LoadProperties("character_properties", "characterId", character.DbId, character.Properties);
			this.LoadProperties("etc_properties", "characterId", character.DbId, character.EtcProperties);
			this.LoadCompanions(character);
			this.LoadParty(character);
			this.LoadGuild(character);
			this.LoadHelp(character);
			this.LoadAchievements(character);
			this.LoadAchievementPoints(character);

			// Initialize the properties to trigger calculated properties
			// and to set some properties in case the character is new and
			// hasn't received its initial properties based on their job's
			// data yet.
			character.InitProperties();

			// We'll simply set stamina to the max on load for now until
			// we do some more research on how stamina works, whether it's
			// saved at all, and what we want the default behavior to be.
			//character.Properties.Stamina = stamina;
			character.Properties.Stamina = (int)character.Properties.GetFloat(PropertyName.MaxSta);

			// Update stance, in case no equip was added, which would've
			// triggered this call.
			character.UpdateStance();

			return character;
		}

		/// <summary>
		/// Load Achievements from the database.
		/// </summary>
		/// <param name="character"></param>
		private void LoadAchievements(Character character)
		{
			using (var conn = this.GetConnection())
			using (var cmd = new MySqlCommand("SELECT * FROM `achievements` WHERE `characterId` = @characterId", conn))
			{
				cmd.Parameters.AddWithValue("@characterId", character.DbId);

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						var achievementId = reader.GetInt32("achievementId");

						if (!character.Achievements.HasAchievement(achievementId))
							character.Achievements.AddAchievement(achievementId, true);
					}
				}
			}
		}

		/// <summary>
		/// Saves character's achievements to the database.
		/// </summary>
		/// <param name="character"></param>
		private void SaveAchievements(Character character)
		{
			var achievements = character.Achievements.GetAchievements();

			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new MySqlCommand("DELETE FROM `achievements` WHERE `characterId` = @characterId", conn, trans))
				{
					cmd.Parameters.AddWithValue("@characterId", character.DbId);
					cmd.ExecuteNonQuery();
				}

				foreach (var achievement in achievements)
				{
					using (var cmd = new InsertCommand("INSERT INTO `achievements` {0}", conn, trans))
					{
						cmd.Set("characterId", character.DbId);
						cmd.Set("achievementId", achievement);

						cmd.Execute();
					}
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Load Achievements from the database.
		/// </summary>
		/// <param name="character"></param>
		private void LoadAchievementPoints(Character character)
		{
			using (var conn = this.GetConnection())
			using (var cmd = new MySqlCommand("SELECT * FROM `achievement_points` WHERE `characterId` = @characterId", conn))
			{
				cmd.Parameters.AddWithValue("@characterId", character.DbId);

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						var pointId = reader.GetInt32("pointId");
						var points = reader.GetInt32("pointValue");

						character.Achievements.AddAchievementPoints(pointId, points);
					}
				}
			}
		}

		/// <summary>
		/// Saves character's achievement points to the database.
		/// </summary>
		/// <param name="character"></param>
		private void SaveAchievementPoints(Character character)
		{
			var pointIds = character.Achievements.GetPointIds();

			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new MySqlCommand("DELETE FROM `achievement_points` WHERE `characterId` = @characterId", conn, trans))
				{
					cmd.Parameters.AddWithValue("@characterId", character.DbId);
					cmd.ExecuteNonQuery();
				}

				foreach (var pointId in pointIds)
				{
					using (var cmd = new InsertCommand("INSERT INTO `achievement_points` {0}", conn, trans))
					{
						cmd.Set("characterId", character.DbId);
						cmd.Set("pointId", pointId);
						cmd.Set("pointValue", character.Achievements.GetPoints(pointId));

						cmd.Execute();
					}
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Load Help (Tutorials) from the database.
		/// </summary>
		/// <param name="character"></param>
		private void LoadHelp(Character character)
		{
			using (var conn = this.GetConnection())
			using (var cmd = new MySqlCommand("SELECT * FROM `help` WHERE `characterId` = @characterId", conn))
			{
				cmd.Parameters.AddWithValue("@characterId", character.DbId);

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						var helpId = reader.GetInt32("helpId");
						var shown = reader.GetByte("shown");

						if (!character.Help.ContainsKey(helpId))
							character.Help.Add(helpId, shown == 1);
					}
				}
			}
			// Load Default Help
			var defaultHelp = ZoneServer.Instance.Data.HelpDb.Entries.Values.Where(a => a.BasicHelp && a.DbSave);
			if (character.Help.Count == 0 || defaultHelp.Count() != character.Help.Count)
			{
				foreach (var help in defaultHelp)
				{
					if (!character.Help.ContainsKey(help.Id))
						character.Help.Add(help.Id, false);
				}
			}
		}

		/// <summary>
		/// Save Help (Tutorials) to database.
		/// </summary>
		/// <param name="characterId"></param>
		/// <param name="helpId"></param>
		/// <param name="isShown"></param>
		public void SaveHelp(long characterId, int helpId, bool isShown)
		{
			using (var conn = this.GetConnection())
			using (var cmd = new InsertCommand("INSERT INTO `help` {0}", conn))
			{
				cmd.Set("characterId", characterId);
				cmd.Set("helpId", helpId);
				cmd.Set("shown", isShown ? 1 : 0);

				cmd.Execute();
			}
		}

		/// <summary>
		/// Loads character's skills.
		/// </summary>
		/// <param name="character"></param>
		private void LoadSkills(Character character)
		{
			using (var conn = this.GetConnection())
			{
				using (var mc = new MySqlCommand("SELECT * FROM `skills` WHERE `characterId` = @characterId", conn))
				{
					mc.Parameters.AddWithValue("@characterId", character.DbId);

					using (var reader = mc.ExecuteReader())
					{
						while (reader.Read())
						{
							var skillId = (SkillId)reader.GetInt32("id");
							var level = reader.GetInt32("level");

							var skill = new Skill(character, skillId, level);

							character.Skills.AddSilent(skill);
						}
					}
				}

				// Properties?
			}
		}

		/// <summary>
		/// Loads character's abilities.
		/// </summary>
		/// <param name="character"></param>
		private void LoadAbilities(Character character)
		{
			using (var conn = this.GetConnection())
			{
				using (var mc = new MySqlCommand("SELECT * FROM `abilities` WHERE `characterId` = @characterId", conn))
				{
					mc.Parameters.AddWithValue("@characterId", character.DbId);

					using (var reader = mc.ExecuteReader())
					{
						while (reader.Read())
						{
							var abilityId = (AbilityId)reader.GetInt32("id");
							var level = reader.GetInt32("level");
							var active = reader.GetBoolean("active");

							var ability = new Ability(abilityId, level);
							ability.Active = active;

							character.Abilities.AddSilent(ability);
						}
					}
				}

				// Properties?
			}
		}

		/// <summary>
		/// Loads character's jobs from the database.
		/// </summary>
		/// <param name="character"></param>
		private void LoadJobs(Character character)
		{
			using (var conn = this.GetConnection())
			using (var mc = new MySqlCommand("SELECT * FROM `jobs` WHERE `characterId` = @characterId", conn))
			{
				mc.Parameters.AddWithValue("@characterId", character.DbId);

				using (var reader = mc.ExecuteReader())
				{
					while (reader.Read())
					{
						var jobId = (JobId)reader.GetInt32("jobId");
						var circle = (JobCircle)reader.GetInt32("circle");
						var skillPoints = reader.GetInt32("skillPoints");
						var totalExp = reader.GetInt64("totalExp");

						var job = new Job(character, jobId, totalExp, circle, skillPoints);

						character.Jobs.AddSilent(job);
					}
				}
			}

			// Fallback if the character doesn't have a job for some reason
			if (character.Jobs.Count == 0)
				character.Jobs.AddSilent(new Job(character, character.JobId));
		}

		/// <summary>
		/// Loads character's session objects.
		/// </summary>
		/// <param name="character"></param>
		private void LoadSessionObjects(Character character)
		{
			using (var conn = this.GetConnection())
			using (var mc = new MySqlCommand("SELECT * FROM `session_objects_properties` WHERE `characterId` = @characterId", conn))
			{
				mc.Parameters.AddWithValue("@characterId", character.DbId);

				using (var reader = mc.ExecuteReader())
				{
					while (reader.Read())
					{
						var sessionObjectId = reader.GetInt32("sessionObjectId"); // session object's class id
						var propertyName = reader.GetString("name");
						var typeStr = reader.GetString("type");
						var valueStr = reader.GetString("value");

						// Hotfix for converting old character property
						// ids to names.
						if (Regex.IsMatch(propertyName, @"^[0-9]+$"))
							propertyName = PropertyTable.GetName("SessionObject", int.Parse(propertyName));

						var sessionObject = character.SessionObjects.GetOrCreate(sessionObjectId);
						var properties = sessionObject.Properties;

						if (typeStr == "f")
						{
							if (!properties.TryGet<FloatProperty>(propertyName, out var property))
								property = properties.Create(new FloatProperty(propertyName));

							property.Deserialize(valueStr);
						}
						else
						{
							if (!properties.TryGet<StringProperty>(propertyName, out var property))
								property = properties.Create(new StringProperty(propertyName));

							property.Deserialize(valueStr);
						}
					}
				}
			}
		}

		/// <summary>
		/// Saves character's session objects.
		/// </summary>
		/// <param name="character"></param>
		private void SaveSessionObjects(Character character)
		{
			var sessionObjects = character.SessionObjects.GetList();

			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new MySqlCommand("DELETE FROM `session_objects_properties` WHERE `characterId` = @characterId", conn, trans))
				{
					cmd.Parameters.AddWithValue("@characterId", character.DbId);
					cmd.ExecuteNonQuery();
				}

				foreach (var sessionObject in sessionObjects)
				{

					var properties = sessionObject.Properties.GetAll();
					foreach (var property in properties)
					{
						var typeStr = property is FloatProperty ? "f" : "s";
						var valueStr = property.Serialize();

						using (var cmd = new InsertCommand("INSERT INTO `session_objects_properties` {0}", conn, trans))
						{
							cmd.Set("characterId", character.DbId);
							cmd.Set("sessionObjectId", sessionObject.Id);
							cmd.Set("name", property.Ident);
							cmd.Set("type", typeStr);
							cmd.Set("value", valueStr);

							cmd.Execute();
						}
					}
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Saves character information.
		/// </summary>
		/// <param name="character"></param>
		/// <returns></returns>
		public bool SaveCharacter(Character character)
		{
			using (var conn = this.GetConnection())
			using (var cmd = new UpdateCommand("UPDATE `characters` SET {0} WHERE `characterId` = @characterId", conn))
			{
				var characterProperties = (CharacterProperties)character.Properties;

				cmd.AddParameter("@characterId", character.DbId);
				cmd.Set("name", character.Name);
				cmd.Set("job", (short)character.JobId);
				cmd.Set("gender", (byte)character.Gender);
				cmd.Set("hair", character.Hair);
				cmd.Set("level", character.Level);
				cmd.Set("zone", character.MapId);
				cmd.Set("x", character.Position.X);
				cmd.Set("y", character.Position.Y);
				cmd.Set("z", character.Position.Z);
				cmd.Set("dir", character.Direction.DegreeAngle);
				cmd.Set("exp", character.Exp);
				cmd.Set("maxExp", character.MaxExp);
				cmd.Set("totalExp", character.TotalExp);
				cmd.Set("equipVisibility", character.VisibleEquip);
				cmd.Set("stamina", character.Properties.Stamina);
				cmd.Set("silver", character.Inventory.CountItem(ItemId.Silver));
				if (character.Connection.Party != null)
					cmd.Set("partyId", character.Connection.Party?.DbId ?? 0);
				if (character.Connection.Guild != null)
					cmd.Set("guildId", character.Connection.Guild?.DbId ?? 0);

				cmd.Execute();
			}

			this.SaveCharacterItems(character);
			this.SaveCharacterWarehouseItems(character);
			this.SaveVariables(character.Variables.Perm, "vars_characters", "characterId", character.DbId);
			this.SaveSessionObjects(character);
			this.SaveProperties("character_properties", "characterId", character.DbId, character.Properties);
			this.SaveProperties("etc_properties", "characterId", character.DbId, character.EtcProperties);
			this.SaveJobs(character);
			this.SaveSkills(character);
			this.SaveAbilities(character);
			this.SaveBuffs(character);
			this.SaveCooldowns(character);
			this.SaveQuests(character);
			if (character.HasCompanions)
				this.SaveCompanions(character);
			this.SaveAchievements(character);
			this.SaveAchievementPoints(character);

			return false;
		}

		/// <summary>
		/// Saves character's skills.
		/// </summary>
		/// <param name="character"></param>
		private void SaveSkills(Character character)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new MySqlCommand("DELETE FROM `skills` WHERE `characterId` = @characterId", conn, trans))
				{
					cmd.Parameters.AddWithValue("@characterId", character.DbId);
					cmd.ExecuteNonQuery();
				}

				var skills = character.Skills.GetList();
				foreach (var skill in skills)
				{
					using (var cmd = new InsertCommand("INSERT INTO `skills` {0}", conn, trans))
					{
						cmd.Set("characterId", character.DbId);
						cmd.Set("id", skill.Id);
						cmd.Set("level", skill.Level);
						cmd.Execute();
					}

					// Properties?
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Saves character's abilities.
		/// </summary>
		/// <param name="character"></param>
		private void SaveAbilities(Character character)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new MySqlCommand("DELETE FROM `abilities` WHERE `characterId` = @characterId", conn, trans))
				{
					cmd.Parameters.AddWithValue("@characterId", character.DbId);
					cmd.ExecuteNonQuery();
				}

				var abilities = character.Abilities.GetList();
				foreach (var ability in abilities)
				{
					using (var cmd = new InsertCommand("INSERT INTO `abilities` {0}", conn, trans))
					{
						cmd.Set("characterId", character.DbId);
						cmd.Set("id", ability.Id);
						cmd.Set("level", ability.Level);
						cmd.Set("active", ability.Active);

						cmd.Execute();
					}

					// Properties?
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Saves character's jobs to the database.
		/// </summary>
		/// <param name="character"></param>
		private void SaveJobs(Character character)
		{
			var jobs = character.Jobs.GetList();

			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new MySqlCommand("DELETE FROM `jobs` WHERE `characterId` = @characterId", conn, trans))
				{
					cmd.Parameters.AddWithValue("@characterId", character.DbId);
					cmd.ExecuteNonQuery();
				}

				foreach (var job in jobs)
				{
					using (var cmd = new InsertCommand("INSERT INTO `jobs` {0}", conn, trans))
					{
						cmd.Set("characterId", character.DbId);
						cmd.Set("jobId", job.Id);
						cmd.Set("circle", job.Circle);
						cmd.Set("skillPoints", job.SkillPoints);
						cmd.Set("totalExp", job.TotalExp);

						cmd.Execute();
					}
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Load character's items.
		/// </summary>
		/// <param name="characterId"></param>
		/// <returns></returns>
		private void LoadCharacterItems(Character character)
		{
			using (var conn = this.GetConnection())
			using (var mc = new MySqlCommand("SELECT `i`.*, `inv`.`sort`, `inv`.`equipSlot` FROM `inventory` AS `inv` INNER JOIN `items` AS `i` ON `inv`.`itemId` = `i`.`itemUniqueId` WHERE `characterId` = @characterId ORDER BY `sort` ASC", conn))
			{
				mc.Parameters.AddWithValue("@characterId", character.DbId);

				using (var reader = mc.ExecuteReader())
				{
					while (reader.Read())
					{
						var itemUniqueId = reader.GetInt64("itemUniqueId");
						var itemId = reader.GetInt32("itemId");
						var amount = reader.GetInt32("amount");
						var equipSlot = (EquipSlot)reader.GetByte("equipSlot");

						// Check item, in case its data was removed
						if (!ZoneServer.Instance.Data.ItemDb.Contains(itemId))
						{
							Log.Warning("ZoneDb.LoadCharacterItems: Item '{0}' not found, removing it from inventory.", itemId);
							continue;
						}

						var item = new Item(itemUniqueId, itemId, amount);
						if (!this.LoadProperties("item_properties", "itemId", item.DbId, item.Properties))
						{
							item.Durability = (int)item.Properties.GetFloat(PropertyName.MaxDur);
						}

						if (!Enum.IsDefined(typeof(EquipSlot), equipSlot))
							character.Inventory.AddSilent(item);
						else
							character.Inventory.SetEquipSilent(equipSlot, item);
					}
				}
			}
		}

		/// <summary>
		/// Load character's warehouse items.
		/// </summary>
		/// <param name="character"></param>
		/// <returns></returns>
		private void LoadCharacterWarehouseItems(Character character)
		{
			using (var conn = this.GetConnection())
			using (var mc = new MySqlCommand("SELECT `i`.*, `inv`.`sort` FROM `warehouse` AS `inv` INNER JOIN `items` AS `i` ON `inv`.`itemId` = `i`.`itemUniqueId` WHERE `characterId` = @characterId ORDER BY `sort` ASC", conn))
			{
				mc.Parameters.AddWithValue("@characterId", character.DbId);

				using (var reader = mc.ExecuteReader())
				{
					while (reader.Read())
					{
						var itemUniqueId = reader.GetInt64("itemUniqueId");
						var itemId = reader.GetInt32("itemId");
						var amount = reader.GetInt32("amount");

						// Check item, in case its data was removed
						if (!ZoneServer.Instance.Data.ItemDb.Contains(itemId))
						{
							Log.Warning("ZoneDb.LoadCharacterItems: Item '{0}' not found, removing it from inventory.", itemId);
							continue;
						}

						var item = new Item(itemUniqueId, itemId, amount);
						if (!this.LoadProperties("item_properties", "itemId", item.DbId, item.Properties))
						{
							item.Durability = (int)item.Properties.GetFloat(PropertyName.MaxDur);
						}

						character.Inventory.AddSilent(item, InventoryType.Warehouse);
					}
				}
			}
		}

		/// <summary>
		/// Returns items for given character.
		/// </summary>
		/// <param name="characterId"></param>
		/// <returns></returns>
		public void SaveCharacterItems(Character character)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var mc = new MySqlCommand("DELETE FROM `inventory` WHERE `characterId` = @characterId", conn, trans))
				{
					mc.Parameters.AddWithValue("@characterId", character.DbId);
					mc.ExecuteNonQuery();
				}

				var i = 0;
				foreach (var item in character.Inventory.GetItems().OrderBy(a => a.Key))
				{
					var newId = 0L;

					// Save the actual items into the items table and the
					// inventory-exclusive values into the inventory table,
					// while linking to the items.
					// TODO: Add generic item load and save methods, for
					//   other item collections to use, such as warehouse.

					using (var cmd = new InsertCommand("INSERT INTO `items` {0}", conn, trans))
					{
						cmd.Set("itemId", item.Value.Id);
						cmd.Set("amount", item.Value.Amount);

						cmd.Execute();

						newId = cmd.LastId;
					}

					using (var cmd = new InsertCommand("INSERT INTO `inventory` {0}", conn, trans))
					{
						cmd.Set("characterId", character.DbId);
						cmd.Set("itemId", newId);
						cmd.Set("sort", i++);
						cmd.Set("equipSlot", 0x7F);

						cmd.Execute();
					}
				}

				// Save only non-dummy equip to the database, and make sure
				// that dummy equip that was loaded into the character as a
				// normal item wrongfully isn't saved again.
				foreach (var item in character.Inventory.GetEquip().Where(a => !(a.Value is DummyEquipItem) && !InventoryDefaults.EquipItems.Contains(a.Value.Id)))
				{
					var newId = 0L;

					using (var cmd = new InsertCommand("INSERT INTO `items` {0}", conn, trans))
					{
						cmd.Set("itemId", item.Value.Id);
						cmd.Set("amount", item.Value.Amount);

						cmd.Execute();

						newId = cmd.LastId;
					}

					using (var cmd = new InsertCommand("INSERT INTO `inventory` {0}", conn, trans))
					{
						cmd.Set("characterId", character.DbId);
						cmd.Set("itemId", newId);
						cmd.Set("sort", 0);
						cmd.Set("equipSlot", (byte)item.Key);

						cmd.Execute();
					}

					this.SaveProperties("item_properties", "itemId", newId, item.Value.Properties, conn, trans);
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Returns warehouse items for given character.
		/// </summary>
		/// <param name="character"></param>
		/// <returns></returns>
		public void SaveCharacterWarehouseItems(Character character)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var mc = new MySqlCommand("DELETE FROM `warehouse` WHERE `characterId` = @characterId", conn, trans))
				{
					mc.Parameters.AddWithValue("@characterId", character.DbId);
					mc.ExecuteNonQuery();
				}

				var items = character.Inventory.GetWarehouseItems();
				for (var i = 0; i < items.Count; i++)
				{
					var item = items[i];
					var newId = 0L;

					// Save the actual items into the items table and the
					// inventory-exclusive values into the inventory table,
					// while linking to the items.
					// TODO: Add generic item load and save methods, for
					//   other item collections to use, such as warehouse.

					using (var cmd = new InsertCommand("INSERT INTO `items` {0}", conn, trans))
					{
						cmd.Set("itemId", item.Id);
						cmd.Set("amount", item.Amount);

						cmd.Execute();

						newId = cmd.LastId;
					}

					using (var cmd = new InsertCommand("INSERT INTO `warehouse` {0}", conn, trans))
					{
						cmd.Set("characterId", character.DbId);
						cmd.Set("itemId", newId);
						cmd.Set("sort", i);

						cmd.Execute();
					}

					this.SaveProperties("item_properties", "itemId", newId, item.Properties, conn, trans);
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Saves variables in database.
		/// </summary>
		/// <param name="vars"></param>
		/// <param name="tableName"></param>
		/// <param name="ownerField"></param>
		/// <param name="ownerId"></param>
		public void SaveVariables(Variables vars, string tableName, string ownerField, long ownerId)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				this.SaveVariables(conn, trans, vars, tableName, ownerField, ownerId);
				trans.Commit();
			}
		}

		/// <summary>
		/// Saves owner's variables in database.
		/// </summary>
		/// <param name="vars"></param>
		/// <param name="tableName"></param>
		/// <param name="ownerField"></param>
		/// <param name="ownerId"></param>
		protected void SaveVariables(MySqlConnection conn, MySqlTransaction trans, Variables vars, string tableName, string ownerField, long ownerId)
		{
			var checkOwner = ownerField != null;
			var where = checkOwner ? $"`{ownerField}` = @ownerId" : "1";

			using (var mc = new MySqlCommand($"DELETE FROM `{tableName}` WHERE {where}", conn, trans))
			{
				if (checkOwner)
					mc.Parameters.AddWithValue("@ownerId", ownerId);
				mc.ExecuteNonQuery();
			}

			foreach (var var in vars.GetList())
			{
				if (var.Value == null)
					continue;

				// Get type
				string type;
				if (var.Value is byte) type = "1u";
				else if (var.Value is ushort) type = "2u";
				else if (var.Value is uint) type = "4u";
				else if (var.Value is ulong) type = "8u";
				else if (var.Value is sbyte) type = "1";
				else if (var.Value is short) type = "2";
				else if (var.Value is int) type = "4";
				else if (var.Value is long) type = "8";
				else if (var.Value is float) type = "f";
				else if (var.Value is double) type = "d";
				else if (var.Value is bool) type = "b";
				else if (var.Value is string) type = "s";
				else if (var.Value is DateTime) type = "dt";
				else if (var.Value is TimeSpan) type = "ts";
				else
				{
					Log.Warning("SaveVars: Skipping variable '{0}', unsupported type '{1}'.", var.Key, var.Value.GetType().Name);
					continue;
				}

				// Get value
				var val = "";
				switch (type)
				{
					case "f": val = ((float)var.Value).ToString(CultureInfo.InvariantCulture); break;
					case "d": val = ((double)var.Value).ToString(CultureInfo.InvariantCulture); break;
					case "dt": val = ((DateTime)var.Value).Ticks.ToString(); break;
					case "ts": val = ((TimeSpan)var.Value).Ticks.ToString(); break;
					default: val = var.Value.ToString(); break;
				}

				// Make sure value isn't too big for the mediumtext field
				// (unlikely as it may be). Size: 16,777,215
				if (val.Length > (1 << 24) - 1)
				{
					Log.Warning("SaveVars: Skipping variable '{0}', it's too big.", var.Key);
					continue;
				}

				// Save
				using (var cmd = new InsertCommand($"INSERT INTO `{tableName}` {{0}}", conn, trans))
				{
					if (checkOwner)
						cmd.Set(ownerField, ownerId);

					cmd.Set("name", var.Key);
					cmd.Set("type", type);
					cmd.Set("value", val);

					cmd.Execute();
				}
			}
		}

		/// <summary>
		/// Loads owner's variables into the variable manager.
		/// </summary>
		/// <param name="vars"></param>
		/// <param name="tableName"></param>
		/// <param name="ownerField"></param>
		/// <param name="ownerId"></param>
		/// <returns></returns>
		public void LoadVars(Variables vars, string tableName, string ownerField, long ownerId)
		{
			using (var conn = this.GetConnection())
				this.LoadVars(conn, vars, tableName, ownerField, ownerId);
		}

		/// <summary>
		/// Loads owner's variables into the variable manager.
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="vars"></param>
		/// <param name="tableName"></param>
		/// <param name="ownerField"></param>
		/// <param name="ownerId"></param>
		/// <returns></returns>
		protected void LoadVars(MySqlConnection conn, Variables vars, string tableName, string ownerField, long ownerId)
		{
			var checkOwner = ownerField != null;
			var where = checkOwner ? $"`{ownerField}` = @ownerId" : "1";

			using (var mc = new MySqlCommand($"SELECT * FROM `{tableName}` WHERE {where}", conn))
			{
				if (checkOwner)
					mc.Parameters.AddWithValue("@ownerId", ownerId);

				using (var reader = mc.ExecuteReader())
				{
					while (reader.Read())
					{
						var name = reader.GetString("name");
						var type = reader.GetString("type");
						var val = reader.GetStringSafe("value");

						if (val == null)
							continue;

						try
						{
							switch (type)
							{
								case "1u": vars.Set(name, byte.Parse(val)); break;
								case "2u": vars.Set(name, ushort.Parse(val)); break;
								case "4u": vars.Set(name, uint.Parse(val)); break;
								case "8u": vars.Set(name, ulong.Parse(val)); break;
								case "1": vars.Set(name, sbyte.Parse(val)); break;
								case "2": vars.Set(name, short.Parse(val)); break;
								case "4": vars.Set(name, int.Parse(val)); break;
								case "8": vars.Set(name, long.Parse(val)); break;
								case "f": vars.Set(name, float.Parse(val, CultureInfo.InvariantCulture)); break;
								case "d": vars.Set(name, double.Parse(val, CultureInfo.InvariantCulture)); break;
								case "b": vars.Set(name, bool.Parse(val)); break;
								case "s": vars.Set(name, val); break;
								case "dt": vars.Set(name, new DateTime(long.Parse(val))); break;
								case "ts": vars.Set(name, new TimeSpan(long.Parse(val))); break;

								default:
									Log.Warning("LoadVars: Unknown variable type '{0}'.", type);
									continue;
							}
						}
						catch (FormatException)
						{
							Log.Warning("LoadVars: Variable '{0}' could not be parsed as type '{1}'. Value: '{2}', Owner: '{3}:{4}'", name, type, val, ownerField, ownerId);
							continue;
						}
						catch (OverflowException)
						{
							Log.Warning("LoadVars: Value '{2}' of variable '{0}' doesn't fit into type '{1}'. Owner: '{3}:{4}'", name, type, val, ownerField, ownerId);
							continue;
						}
					}
				}
			}
		}

		/// <summary>
		/// Loads chat macros from the database.
		/// </summary>
		/// <param name="account"></param>
		private void LoadChatMacros(Account account)
		{
			using (var conn = this.GetConnection())
			using (var mc = new MySqlCommand("SELECT * FROM `chatMacros` WHERE `accountId` = @accountId ORDER BY `index` DESC", conn))
			{
				mc.Parameters.AddWithValue("@accountId", account.Id);

				using (var reader = mc.ExecuteReader())
				{
					while (reader.Read())
					{
						var index = reader.GetInt32("index");
						var message = reader.GetString("message");
						var pose = reader.GetInt32("pose");

						var macro = new ChatMacro(index, message, pose);
						account.AddChatMacro(macro);
					}
				}
			}
		}

		/// <summary>
		/// Persists the account's chat macros to the database.
		/// </summary>
		/// <param name="account"></param>
		private void SaveChatMacros(Account account)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var mc = new MySqlCommand("DELETE FROM `chatMacros` WHERE `accountId` = @accountId", conn, trans))
				{
					mc.Parameters.AddWithValue("@accountId", account.Id);
					mc.ExecuteNonQuery();
				}

				foreach (var macro in account.GetChatMacros().OrderBy(x => x.Index))
				{
					using (var cmd = new InsertCommand("INSERT INTO `chatMacros` {0}", conn))
					{
						cmd.Set("accountId", account.Id);
						cmd.Set("index", macro.Index);
						cmd.Set("message", macro.Message);
						cmd.Set("pose", macro.Pose);

						cmd.Execute();
					}
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Loads revealed maps for the account.
		/// </summary>
		/// <param name="account"></param>
		private void LoadRevealedMaps(Account account)
		{
			using (var conn = this.GetConnection())
			using (var mc = new MySqlCommand("SELECT * FROM `revealedMaps` WHERE `accountId` = @accountId", conn))
			{
				mc.Parameters.AddWithValue("@accountId", account.Id);

				using (var reader = mc.ExecuteReader())
				{
					while (reader.Read())
					{
						var map = reader.GetInt32("map");
						var explored = (byte[])reader["explored"];
						var percentage = reader.GetFloat("percentage");

						var revealedMap = new RevealedMap(map, explored, percentage);
						account.AddRevealedMap(revealedMap);
					}
				}
			}
		}

		/// <summary>
		/// Loads assisters for the account.
		/// </summary>
		/// <param name="account"></param>
		private void LoadAssisters(Account account)
		{
			if (!account.IsAssistersEnabled)
				return;
			using (var conn = this.GetConnection())
			using (var mc = new MySqlCommand("SELECT * FROM `assisters` WHERE `accountId` = @accountId", conn))
			{
				mc.Parameters.AddWithValue("@accountId", account.Id);

				using (var reader = mc.ExecuteReader())
				{
					while (reader.Read())
					{
						var card = new AssisterCard(reader.GetInt64("assisterId"), reader.GetString("name"), reader.GetInt16("slot"));
						card.Experience = reader.GetInt64("exp");

						account.AssisterCabinet.Add(card, true);
					}
				}
			}
		}

		/// <summary>
		/// Persists the account's revealed maps to the database.
		/// </summary>
		/// <param name="account"></param>
		private void SaveRevealedMaps(Account account)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var mc = new MySqlCommand("DELETE FROM `revealedMaps` WHERE `accountId` = @accountId", conn, trans))
				{
					mc.Parameters.AddWithValue("@accountId", account.Id);
					mc.ExecuteNonQuery();
				}

				foreach (var revealedMap in account.GetRevealedMaps())
				{
					using (var cmd = new InsertCommand("INSERT INTO `revealedMaps` {0}", conn, trans))
					{
						cmd.Set("accountId", account.Id);
						cmd.Set("map", revealedMap.MapId);
						cmd.Set("explored", revealedMap.Explored);
						cmd.Set("percentage", revealedMap.Percentage);

						cmd.Execute();
					}
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Persists the account's assisters to the database.
		/// </summary>
		/// <param name="account"></param>
		private void SaveAssisters(Account account)
		{
			if (!account.IsAssistersEnabled)
				return;

			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				foreach (var assister in account.AssisterCabinet.GetAssisters())
				{
					using (var cmd = new InsertCommand("INSERT INTO `assisters` {0}", conn, trans))
					{
						cmd.Set("assisterId", assister.DbId);
						cmd.Set("accountId", account.Id);
						cmd.Set("name", assister.Name);
						cmd.Set("slot", assister.Slot);
						cmd.Set("exp", assister.Experience);

						cmd.Execute();
					}
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Inserts assister in database.
		/// </summary>
		/// <param name="accountId"></param>
		/// <param name="assister"></param>
		/// <returns></returns>
		public void CreateAssister(long accountId, ref AssisterCard assister)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new InsertCommand("INSERT INTO `assisters` {0}", conn, trans))
				{
					cmd.Set("accountId", accountId);
					cmd.Set("name", assister.Name);
					cmd.Set("slot", assister.Slot);
					cmd.Set("exp", assister.Experience);

					cmd.Execute();
					assister.DbId = cmd.LastId;
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Inserts companion in database.
		/// </summary>
		/// <param name="character"></param>
		private void SaveBuffs(Character character)
		{
			var buffs = new Dictionary<long, Buff>();

			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new MySqlCommand("DELETE FROM `buffs` WHERE `characterId` = @characterId", conn, trans))
				{
					cmd.Parameters.AddWithValue("@characterId", character.DbId);
					cmd.ExecuteNonQuery();
				}

				foreach (var buff in character.Buffs.GetList())
				{
					if (!buff.Data.Save)
						continue;

					var lastId = 0L;

					using (var cmd = new InsertCommand("INSERT INTO `buffs` {0}", conn, trans))
					{
						cmd.Set("characterId", character.DbId);
						cmd.Set("classId", buff.Id);
						cmd.Set("numArg1", buff.NumArg1);
						cmd.Set("numArg2", buff.NumArg2);
						cmd.Set("remainingDuration", buff.RemainingDuration);

						cmd.Execute();
						lastId = cmd.LastId;
					}

					this.SaveVariables(conn, trans, buff.Vars, "vars_buffs", "buffId", lastId);
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Loads buffs for the character.
		/// </summary>
		/// <param name="character"></param>
		private void LoadBuffs(Character character)
		{
			var buffs = new Dictionary<long, Buff>();

			using (var conn = this.GetConnection())
			{
				using (var cmd = new MySqlCommand("SELECT * FROM `buffs` WHERE `characterId` = @characterId", conn))
				{
					cmd.Parameters.AddWithValue("@characterId", character.DbId);

					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							var dbId = reader.GetInt64("buffId");
							var classId = (BuffId)reader.GetInt32("classId");
							var numArg1 = reader.GetInt32("numArg1");
							var numArg2 = reader.GetInt32("numArg2");
							var remainingDuration = reader.GetTimeSpan("remainingDuration");

							var buff = new Buff(classId, numArg1, numArg2, remainingDuration, character, character);
							buffs.Add(dbId, buff);
						}
					}
				}

				foreach (var buff in buffs)
				{
					this.LoadVars(conn, buff.Value.Vars, "vars_buffs", "buffId", buff.Key);
					character.Buffs.Restore(buff.Value);
				}
			}
		}

		/// <summary>
		/// Saves character's cooldowns.
		/// </summary>
		/// <param name="character"></param>
		private void SaveCooldowns(Character character)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new MySqlCommand("DELETE FROM `cooldowns` WHERE `characterId` = @characterId", conn, trans))
				{
					cmd.Parameters.AddWithValue("@characterId", character.DbId);
					cmd.ExecuteNonQuery();
				}

				foreach (var cooldown in character.Components.Get<CooldownComponent>().GetAll())
				{
					using (var cmd = new InsertCommand("INSERT INTO `cooldowns` {0}", conn, trans))
					{
						cmd.Set("characterId", character.DbId);
						cmd.Set("classId", cooldown.Id);
						cmd.Set("remaining", cooldown.Remaining);
						cmd.Set("duration", cooldown.Duration);
						cmd.Set("startTime", cooldown.StartTime);

						cmd.Execute();
					}
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Loads cooldowns for the character.
		/// </summary>
		/// <param name="character"></param>
		private void LoadCooldowns(Character character)
		{
			using (var conn = this.GetConnection())
			using (var cmd = new MySqlCommand("SELECT * FROM `cooldowns` WHERE `characterId` = @characterId", conn))
			{
				cmd.Parameters.AddWithValue("@characterId", character.DbId);

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						// We load and save the remaining duration because
						// the game has the capability to freeze cooldowns
						// while logged out. That's not currently used by
						// any cooldowns, but this way we're prepared.

						var classId = (CooldownId)reader.GetInt32("classId");
						var remaining = reader.GetTimeSpan("remaining");
						var duration = reader.GetTimeSpan("duration");
						var startTime = reader.GetDateTimeSafe("startTime");

						var endTime = startTime + duration;
						var updatedRemaining = Math2.Max(TimeSpan.Zero, endTime - DateTime.Now);

						if (updatedRemaining == TimeSpan.Zero)
							continue;

						var cooldown = new Cooldown(classId, updatedRemaining, duration, startTime);
						character.Components.Get<CooldownComponent>().Restore(cooldown);
					}
				}
			}
		}

		/// <summary>
		/// Saves the character's quests to the database.
		/// </summary>
		/// <param name="character"></param>
		/// <exception cref="InvalidOperationException"></exception>
		private void SaveQuests(Character character)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new MySqlCommand("DELETE FROM `quests` WHERE `characterId` = @characterId", conn, trans))
				{
					cmd.AddParameter("@characterId", character.DbId);
					cmd.ExecuteNonQuery();
				}

				foreach (var quest in character.Quests.GetList())
				{
					var questId = 0L;

					using (var cmd = new InsertCommand("INSERT INTO `quests` {0}", conn, trans))
					{
						cmd.Set("characterId", character.DbId);
						cmd.Set("classId", quest.Data.Id);
						cmd.Set("status", (int)quest.Status);
						cmd.Set("startTime", quest.StartTime);
						cmd.Set("completeTime", quest.CompleteTime);

						cmd.Execute();

						questId = cmd.LastId;
					}

					foreach (var progress in quest.Progresses)
					{
						using (var cmd = new InsertCommand("INSERT INTO `quests_progress` {0}", conn, trans))
						{
							cmd.Set("questId", questId);
							cmd.Set("characterId", character.DbId);
							cmd.Set("ident", progress.Objective.Ident);
							cmd.Set("count", progress.Count);
							cmd.Set("done", progress.Done);
							cmd.Set("unlocked", progress.Unlocked);

							cmd.Execute();
						}
					}
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Loads the character's quests from the database.
		/// </summary>
		/// <param name="character"></param>
		private void LoadQuests(Character character)
		{
			using (var conn = this.GetConnection())
			{
				var loadedQuests = new Dictionary<long, Quest>();

				using (var cmd = new MySqlCommand("SELECT * FROM `quests` WHERE `characterId` = @characterId", conn))
				{
					cmd.AddParameter("@characterId", character.DbId);

					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							var questDbId = reader.GetInt64("questId");
							var questClassId = reader.GetInt32("classId");
							var status = (QuestStatus)reader.GetInt32("status");
							var startTime = reader.GetDateTimeSafe("startTime");
							var completeTime = reader.GetDateTimeSafe("completeTime");

							// Skip quests without scripts
							if (!QuestScript.TryGet(questClassId, out var questScript))
								continue;

							var quest = Quest.Create(questClassId);
							quest.Status = status;
							quest.StartTime = startTime;
							quest.CompleteTime = completeTime;

							character.Quests.AddSilent(quest);
							loadedQuests.Add(questDbId, quest);
						}
					}
				}

				using (var cmd = new MySqlCommand("SELECT * FROM `quests_progress` WHERE `characterId` = @characterId", conn))
				{
					cmd.AddParameter("@characterId", character.DbId);

					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							var questDbId = reader.GetInt64("questId");
							var ident = reader.GetStringSafe("ident");
							var count = reader.GetInt32("count");
							var done = reader.GetBoolean("done");
							var unlocked = reader.GetBoolean("unlocked");

							if (!loadedQuests.TryGetValue(questDbId, out var quest))
							{
								Log.Warning("ZoneDb.LoadQuests: Progress '{0}' loaded for a quest that doesn't exist.", ident);
								continue;
							}

							if (!quest.TryGetProgress(ident, out var progress))
							{
								Log.Warning("ZoneDb.LoadQuests: Progress '{0}' loaded for quest '{1}', but the objective doesn't exist.", ident, quest.Data.Id);
								continue;
							}

							progress.Count = count;
							progress.Done = done;
							progress.Unlocked = unlocked;
						}
					}
				}
			}
		}

		/// <summary>
		/// Inserts companion in database.
		/// </summary>
		/// <param name="accountId"></param>
		/// <param name="character"></param>
		/// <returns></returns>
		public void CreateCompanion(long accountId, long characterId, Companion companion)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new InsertCommand("INSERT INTO `companions` {0}", conn, trans))
				{
					companion.AdoptTime = DateTime.Now;

					cmd.Set("accountId", accountId);
					cmd.Set("characterId", characterId);
					cmd.Set("name", companion.Name);
					cmd.Set("monsterId", companion.Id);
					cmd.Set("stamina", companion.Stamina);
					cmd.Set("exp", companion.Experience);
					cmd.Set("adoptTime", companion.AdoptTime);
					cmd.Set("active", companion.IsActivated ? 1 : 0);

					cmd.Execute();
					companion.DbId = cmd.LastId;
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Inserts party in database.
		/// </summary>
		/// <param name="party"></param>
		/// <returns></returns>
		public void CreateParty(Party party)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new InsertCommand("INSERT INTO `party` {0}", conn, trans))
				{
					party.DateCreated = DateTime.Now;

					cmd.Set("name", party.Name);
					cmd.Set("leaderId", party.LeaderDbId);
					cmd.Set("note", party.Note);
					cmd.Set("questSharing", (int)party.QuestSharing);
					cmd.Set("expDistribution", (int)party.ExpDistribution);
					cmd.Set("itemDistribution", (int)party.ItemDistribution);
					cmd.Set("dateCreated", party.DateCreated);

					cmd.Execute();
					party.DbId = cmd.LastId;
				}

				foreach (var member in party.GetMembers())
				{
					using (var cmd = new UpdateCommand("UPDATE `characters` SET {0} WHERE `characterId` = @characterId", conn))
					{
						cmd.AddParameter("@characterId", member.DbId);
						cmd.Set("partyId", party.DbId);

						cmd.Execute();
					}
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Loads party from database.
		/// </summary>
		/// <returns></returns>
		public void LoadParty(Character character)
		{
			if (character.PartyId <= 0)
				return;
			var party = ZoneServer.Instance.World.GetParty(character.PartyId);
			if (party == null)
			{
				using (var conn = this.GetConnection())
				{
					using (var mc = new MySqlCommand("SELECT * FROM `party` WHERE `partyId` = @partyId", conn))
					{
						mc.Parameters.AddWithValue("@partyId", character.PartyId);

						using (var reader = mc.ExecuteReader())
						{
							while (reader.Read())
							{
								party = new Party(reader.GetInt64("partyId"), reader.GetInt64("leaderId"), reader.GetString("name"), reader.GetDateTime("dateCreated"), reader.GetString("note"),
									(PartyItemDistribution)reader.GetByte("itemDistribution"), (PartyExpDistribution)reader.GetByte("expDistribution"), (PartyQuestSharing)reader.GetByte("questSharing"));

								this.LoadPartyMembers(character, party);

								ZoneServer.Instance.World.Parties.Add(party);
							}
						}
					}
				}
			}
			else
			{
				var member = party.GetMember(character.ObjectId);
				if (member != null)
					member.IsOnline = true;
			}
		}

		private void LoadPartyMembers(Character loadCharacter, Party party)
		{
			using (var conn = this.GetConnection())
			{
				using (var mc = new MySqlCommand("SELECT * FROM `characters` WHERE `partyId` = @partyId", conn))
				{
					mc.Parameters.AddWithValue("@partyId", party.DbId);
					using (var reader = mc.ExecuteReader())
					{
						while (reader.Read())
						{
							var character = ZoneServer.Instance.World.GetCharacter(c => c.DbId == reader.GetInt64("characterId"));
							if (character == null)
							{
								var member = new PartyMember
								{
									DbId = reader.GetInt64("characterId"),
									AccountId = reader.GetInt64("accountId"),
									Name = reader.GetStringSafe("name"),
									TeamName = reader.GetStringSafe("teamName"),
									VisualJobId = (JobId)reader.GetInt16("job"),
									Gender = (Gender)reader.GetByte("gender"),
									Hair = reader.GetInt32("hair"),
									MapId = reader.GetInt32("zone"),
								};
								var x = reader.GetFloat("x");
								var y = reader.GetFloat("y");
								var z = reader.GetFloat("z");
								member.Position = new Position(x, y, z);
								member.IsOnline = loadCharacter.DbId == member.DbId;
								party.AddMember(member);
							}
							else
								party.AddMember(character, true);
						}
					}
				}
			}
		}

		/// <summary>
		/// Returns given companion, or null if it doesn't exist.
		/// </summary>
		/// <param name="character"></param>
		/// <returns></returns>
		public Companion GetCompanion(Character character)
		{
			using (var conn = this.GetConnection())
			using (var mc = new MySqlCommand("SELECT * FROM `companions` WHERE `characterId` = @characterId", conn))
			{
				mc.Parameters.AddWithValue("@characterId", character.DbId);

				using (var reader = mc.ExecuteReader())
				{
					if (!reader.Read())
						return null;

					var companion = new Companion(character, reader.GetInt32("monsterId"), MonsterType.Friendly);
					companion.DbId = reader.GetInt64("companionId");
					companion.Name = reader.GetStringSafe("name");
					companion.Stamina = reader.GetInt32("stamina");
					companion.Experience = reader.GetInt32("exp");
					companion.IsActivated = reader.GetByte("active") == 1;

					companion.Position = Position.Zero;
					companion.Direction = new Direction(0);

					return companion;
				}
			}
		}

		/// <summary>
		/// Loads character's companion from the database.
		/// </summary>
		/// <param name="character"></param>
		private void LoadCompanions(Character character)
		{
			using (var conn = this.GetConnection())
			using (var mc = new MySqlCommand("SELECT * FROM `companions` WHERE `characterId` = @characterId", conn))
			{
				mc.Parameters.AddWithValue("@characterId", character.DbId);

				using (var reader = mc.ExecuteReader())
				{
					if (!reader.Read())
						return;

					var companion = new Companion(character, reader.GetInt32("monsterId"), MonsterType.Friendly);
					companion.DbId = reader.GetInt64("companionId");
					companion.Name = reader.GetStringSafe("name");
					companion.Stamina = reader.GetInt32("stamina");
					companion.Experience = reader.GetInt64("exp");
					companion.IsActivated = reader.GetByte("active") == 1;

					companion.Position = Position.Zero;
					companion.Direction = new Direction(0);

					character.AddCompanion(companion, true);
				}
			}
		}

		/// <summary>
		/// Persists the character's companions to the database.
		/// </summary>
		/// <param name="character"></param>
		private void SaveCompanions(Character character)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				foreach (var companion in character.GetCompanions())
				{
					using (var cmd = new UpdateCommand("UPDATE `companions` SET {0} WHERE `companionId` = @companionId", conn))
					{
						cmd.AddParameter("@companionId", companion.Id);
						cmd.Set("accountId", character.AccountDbId);
						cmd.Set("characterId", character.DbId);
						cmd.Set("name", companion.Name);
						cmd.Set("stamina", companion.Stamina);
						cmd.Set("exp", companion.Experience);
						cmd.Set("active", companion.IsActivated ? 1 : 0);

						cmd.Execute();
					}
				}

				trans.Commit();
			}
		}

		public void DeleteParty(Party party)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new MySqlCommand("DELETE FROM `party` WHERE `partyId` = @partyId", conn, trans))
				{
					cmd.Parameters.AddWithValue("@partyId", party.DbId);
					cmd.ExecuteNonQuery();
				}


				foreach (var member in party.GetMembers())
				{
					using (var cmd = new UpdateCommand("UPDATE `characters` SET {0} WHERE `characterId` = @characterId", conn, trans))
					{
						cmd.AddParameter("@characterId", member.DbId);
						cmd.Set("partyId", 0);
						cmd.Execute();
					}
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Inserts guild in database.
		/// </summary>
		/// <param name="guild"></param>
		/// <returns></returns>
		public void CreateGuild(Guild guild)
		{
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new InsertCommand("INSERT INTO `guild` {0}", conn, trans))
				{
					guild.DateCreated = DateTime.Now;

					cmd.Set("name", guild.Name);
					cmd.Set("leaderId", guild.LeaderDbId);
					cmd.Set("dateCreated", guild.DateCreated);
					//cmd.Set("level", guild.Level);

					cmd.Execute();
					guild.DbId = cmd.LastId;
				}

				foreach (var member in guild.GetMembers())
				{
					using (var cmd = new UpdateCommand("UPDATE `characters` SET {0} WHERE `characterId` = @characterId", conn))
					{
						cmd.AddParameter("@characterId", member.DbId);
						cmd.Set("guildId", guild.DbId);

						cmd.Execute();
					}
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Loads party from database.
		/// </summary>
		/// <returns></returns>
		public void LoadGuild(Character character)
		{
			if (character.GuildId <= 0)
				return;
			var guild = ZoneServer.Instance.World.GetGuild(character.GuildId);
			if (guild == null)
			{
				using (var conn = this.GetConnection())
				{
					using (var mc = new MySqlCommand("SELECT * FROM `guild` WHERE `guildId` = @guildId", conn))
					{
						mc.Parameters.AddWithValue("@guildId", character.GuildId);

						using (var reader = mc.ExecuteReader())
						{
							while (reader.Read())
							{
								guild = new Guild();
								guild.DbId = reader.GetInt64("guildId");
								guild.Name = reader.GetString("name");
								guild.LeaderDbId = reader.GetInt64("leaderId");
								guild.DateCreated = reader.GetDateTime("dateCreated");

								this.LoadGuildMembers(character, guild);

								ZoneServer.Instance.World.Guilds.Add(guild);
							}

						}
					}
				}
			}
			else
			{
				var member = guild.GetMember(character.ObjectId);
				if (member != null)
					member.IsOnline = true;
			}

		}

		private void LoadGuildMembers(Character loadCharacter, Guild guild)
		{
			using (var conn = this.GetConnection())
			{
				using (var mc = new MySqlCommand("SELECT * FROM `characters` WHERE `guildId` = @guildId", conn))
				{
					mc.Parameters.AddWithValue("@guildId", guild.DbId);
					using (var reader = mc.ExecuteReader())
					{
						while (reader.Read())
						{
							var character = ZoneServer.Instance.World.GetCharacter(c => c.DbId == reader.GetInt64("characterId"));
							if (character == null)
							{
								var member = new Character
								{
									DbId = reader.GetInt64("characterId"),
									AccountDbId = reader.GetInt64("accountId"),
									Name = reader.GetStringSafe("name"),
									TeamName = reader.GetStringSafe("teamName"),
									Gender = (Gender)reader.GetByte("gender"),
									Hair = reader.GetInt32("hair"),
									MapId = reader.GetInt32("zone"),
								};
								var x = reader.GetFloat("x");
								var y = reader.GetFloat("y");
								var z = reader.GetFloat("z");
								member.Position = new Position(x, y, z);
								if (member.DbId == character.DbId)
									member.IsOnline = true;
								guild.AddMember(member);
							}
							else
								guild.AddMember(character, true);
						}
					}
				}
			}
		}

		/// <summary>
		/// Saves house to database.
		/// </summary>
		/// <param name="house"></param>
		public void SaveHouse(PersonalHouse house)
		{
			if (house == null)
				return;
			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new MySqlCommand("DELETE FROM `houses` WHERE `houseId` = @houseId", conn, trans))
				{
					cmd.Parameters.AddWithValue("@houseId", house.Id);
					cmd.ExecuteNonQuery();
				}

				using (var cmd = new InsertCommand("INSERT INTO `houses` {0}", conn, trans))
				{
					cmd.Set("houseId", house.Id);
					cmd.Set("name", house.Name);
					cmd.Set("ownerId", house.OwnerId);
					cmd.Set("ownerName", house.OwnerName);
					cmd.Set("mapId", house.MapId);
					cmd.Set("lastEnterTime", house.LastEnterTime);

					cmd.Execute();
				}

				foreach (var prop in house.Props)
				{
					using (var cmd = new InsertCommand("INSERT INTO `house_props` {0}", conn, trans))
					{
						cmd.Set("houseId", house.Id);
						cmd.Set("monsterId", prop.MonsterId);
						cmd.Set("furnitureId", prop.FurnitureId);
						cmd.Set("x", prop.Position.X);
						cmd.Set("y", prop.Position.Y);
						cmd.Set("z", prop.Position.Z);
						cmd.Set("dir", prop.Direction.ToCardinalDirection());

						cmd.Execute();
					}
				}

				trans.Commit();
			}
		}

		/// <summary>
		/// Save an item listed on the market.
		/// </summary>
		/// <param name="character"></param>
		/// <param name="item"></param>
		/// <param name="itemPrice"></param>
		/// <param name="saleLength"></param>
		public void SaveMarketItem(Character character, Item item, long itemPrice, int saleLength)
		{
			if (character == null || item == null)
				return;
			if (!item.IsSaved)
				item.DbId = this.SaveItem(item);

			using (var conn = this.GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new InsertCommand("INSERT INTO `market_items` {0}", conn, trans))
				{
					var registerDate = DateTime.Now;
					var expireDate = registerDate.AddDays(saleLength);
					cmd.Set("itemUniqueId", item.Id);
					cmd.Set("sellerId", character.DbId);
					cmd.Set("price", itemPrice);
					cmd.Set("dateRegistered", registerDate);
					cmd.Set("dateExpired", expireDate);
					cmd.Set("status", MarketItemStatus.Listed);
					cmd.Execute();
					//market.Id = cmd.LastId;
				}
				trans.Commit();
			}
		}

		/// <summary>
		/// Save Item
		/// </summary>
		/// <param name="item"></param>
		private long SaveItem(Item item)
		{
			using (var conn = this.GetConnection())
			using (var cmd = new InsertCommand("INSERT INTO `items` {0}", conn))
			{
				cmd.Set("itemId", item.Id);
				cmd.Set("amount", item.Amount);

				cmd.Execute();

				return cmd.LastId;
			}
		}

		/// <summary>
		/// Cancel an item listed on the market.
		/// </summary>
		/// <param name="character"></param>
		/// <param name="marketWorldId"></param>
		/// <returns></returns>
		public bool CancelMarketItem(Character character, long marketWorldId)
		{
			using (var conn = this.GetConnection())
			using (var cmd = new UpdateCommand("UPDATE `market_items` SET {0} WHERE `characterId` = @characterId AND `marketItemUniqueId` = @marketId", conn))
			{
				var date = DateTime.Now;
				cmd.AddParameter("@characterId", character.DbId);
				cmd.AddParameter("@marketId", marketWorldId);
				cmd.Set("dateExpired", date);
				cmd.Set("status", MarketItemStatus.Cancelled);
				if (cmd.Execute() == 0)
					return false;
			}

			return true;
		}
		/// <summary>
		/// Get Market Items for a specific character
		/// </summary>
		/// <param name="character"></param>
		/// <returns></returns>
		public List<ItemList> GetMarketItems(Character character, bool isExpiredOrCancelledOrBought = true)
		{
			var result = new List<ItemList>();
			if (character == null)
				return result;
			using (var conn = this.GetConnection())
			using (var cmd = new MySqlCommand("SELECT `market_items`.*, `items`.`itemId`, `items`.`amount` FROM `market_items` INNER JOIN `items` ON `market_items`.`itemUniqueId` = `items`.`itemUniqueId` WHERE `sellerId` = @characterId OR `buyerId` = @characterId", conn))
			{
				cmd.Parameters.AddWithValue("@characterId", character.DbId);
				using (var reader = cmd.ExecuteReader())
				{
					if (!reader.Read())
						return result;
					var item = new ItemList(reader.GetInt32("itemId"));
					item.ItemGuid = reader.GetInt64("itemUniqueId");
					item.MarketGuid = reader.GetInt64("marketItemUniqueId");
					item.RegTime = reader.GetDateTimeSafe("dateRegistered");
					item.EndTime = reader.GetDateTimeSafe("dateExpired");
					item.SellPrice = reader.GetInt32("price");
					item.SellerId = reader.GetInt64("sellerId");
					item.BuyerId = reader.GetInt64("buyerId");
					item.Status = (MarketItemStatus)reader.GetByte("status");
					item.IsMine = true;
					item.IsPrivate = true;
					if (isExpiredOrCancelledOrBought)
					{
						if (item.IsSold || item.IsExpired || item.IsCancelled || item.BuyerId == character.DbId)
							result.Add(item);
					}
					else
						result.Add(item);
				}
			}
			return result;
		}
		/// <summary>
		/// Get Market Item from Database
		/// </summary>
		/// <param name="marketWorldId"></param>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool GetMarketItem(long marketWorldId, out ItemList item)
		{
			item = default;
			using (var conn = GetConnection())
			using (var cmd = new MySqlCommand("SELECT `market_items`.*, `items`.`itemId`, `items`.`amount` FROM `market_items` INNER JOIN `items` ON `market_items`.`itemUniqueId` = `items`.`itemUniqueId` WHERE `marketitemUniqueId` = @marketitemUniqueId", conn))
			{
				cmd.Parameters.AddWithValue("@marketitemUniqueId", marketWorldId);
				using (var reader = cmd.ExecuteReader())
				{
					if (!reader.Read())
						return false;
					item = new ItemList(reader.GetInt32("itemId"));
					item.MarketGuid = marketWorldId;
					item.ItemGuid = reader.GetInt64("itemUniqueId");
					item.Count = reader.GetInt32("amount");
					item.RegTime = reader.GetDateTimeSafe("dateRegistered");
					item.EndTime = reader.GetDateTimeSafe("dateExpired");
					item.SellPrice = reader.GetInt32("price");
					item.SellerId = reader.GetInt64("sellerId");
					item.BuyerId = reader.GetInt64("buyerId");
					item.Status = (MarketItemStatus)reader.GetByte("status");
					item.IsMine = false;
					item.IsPrivate = false;
				}
			}
			return item != null;
		}
		/// <summary>
		/// Get Market Item from Database
		/// for a specific character.
		/// </summary>
		/// <param name="itemWorldId"></param>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool GetMarketItem(long characterId, long itemWorldId, out ItemList item)
		{
			item = default;
			using (var conn = this.GetConnection())
			using (var cmd = new MySqlCommand("SELECT `market_items`.*, `items`.`itemId`, `items`.`amount` FROM `market_items` INNER JOIN `items` ON `market_items`.`itemUniqueId` = `items`.`itemUniqueId` WHERE `sellerId` = @characterId AND `market_items`.`itemUniqueId` = @itemUniqueId", conn))
			{
				cmd.Parameters.AddWithValue("@characterId", characterId);
				cmd.Parameters.AddWithValue("@itemUniqueId", itemWorldId);
				using (var reader = cmd.ExecuteReader())
				{
					if (!reader.Read())
						return false;
					item = new ItemList(reader.GetInt32("itemId"));
					item.ItemGuid = itemWorldId;
					item.MarketGuid = reader.GetInt64("marketitemUniqueId");
					item.Count = reader.GetInt32("amount");
					item.RegTime = reader.GetDateTimeSafe("dateRegistered");
					item.EndTime = reader.GetDateTimeSafe("dateExpired");
					item.SellPrice = reader.GetInt32("price");
					item.Status = (MarketItemStatus)reader.GetByte("status");
					item.SellerId = reader.GetInt64("sellerId");
					item.BuyerId = reader.GetInt64("buyerId");
					item.IsMine = true;
					item.IsPrivate = true;
				}
			}
			return item != null;
		}
		/// <summary>
		/// Delete market item
		/// </summary>
		/// <param name="characterId"></param>
		/// <param name="itemWorldId"></param>
		public void DeleteMarketItem(long characterId, long itemWorldId)
		{
			using (var conn = GetConnection())
			using (var trans = conn.BeginTransaction())
			{
				using (var cmd = new MySqlCommand("DELETE FROM `market_items` WHERE `sellerId` = @characterId AND `itemUniqueId` = @itemUniqueId", conn))
				{
					cmd.Parameters.AddWithValue("@characterId", characterId);
					cmd.Parameters.AddWithValue("@itemUniqueId", itemWorldId);
					cmd.ExecuteNonQuery();
				}
				trans.Commit();
			}
		}

		/// <summary>
		/// Update a market item buyer after purchase
		/// </summary>
		/// <param name="marketWorldId"></param>
		/// <param name="characterId"></param>
		/// <returns></returns>
		public bool UpdateMarketItemBuyer(long marketWorldId, long characterId)
		{

			using (var conn = GetConnection())
			using (var cmd = new UpdateCommand("UPDATE `market_items` SET {0} WHERE `marketItemUniqueId` = @marketItemUniqueId", conn))
			{
				cmd.AddParameter("@marketItemUniqueId", marketWorldId);
				cmd.Set("buyerId", characterId);
				cmd.Set("status", MarketItemStatus.Sold);

				return cmd.Execute() == 1;
			}
		}

		/// <summary>
		/// Update a market item buyer after purchase
		/// </summary>
		/// <param name="marketWorldId"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public bool UpdateMarketItemStatus(long marketWorldId, MarketItemStatus status)
		{

			using (var conn = GetConnection())
			using (var cmd = new UpdateCommand("UPDATE `market_items` SET {0} WHERE `marketItemUniqueId` = @marketItemUniqueId", conn))
			{
				cmd.AddParameter("@marketItemUniqueId", marketWorldId);
				cmd.Set("status", (byte)status);

				return cmd.Execute() == 1;
			}
		}

		/// <summary>
		/// Modify an item's amount.
		/// </summary>
		/// <param name="itemUniqueId"></param>
		/// <param name="amount"></param>
		/// <returns></returns>
		public bool ModifyItemAmount(long itemUniqueId, int amount)
		{
			using (var conn = this.GetConnection())
			using (var cmd = new UpdateCommand("UPDATE `items` SET {0} WHERE `itemUniqueId` = @itemUniqueId", conn))
			{
				cmd.AddParameter("@itemUniqueId", itemUniqueId);
				cmd.Set("amount", amount);

				return cmd.Execute() == 1;
			}
		}

		/// <summary>
		/// Returns global job count
		/// </summary>
		/// <returns></returns>
		public Dictionary<int, int> GetGlobalJobCount()
		{
			var jobDictionary = new Dictionary<int, int>();

			using (var conn = this.GetConnection())
			using (var cmd = new MySqlCommand("SELECT `jobId`, count(*) as `jobCount` FROM `jobs` GROUP BY `jobId` ORDER BY `jobCount` DESC", conn))
			{
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						jobDictionary.Add(reader.GetInt32("jobId"), reader.GetInt32("jobCount"));
					}
				}
			}

			return jobDictionary;
		}

		/// <summary>
		/// Saves session key.
		/// </summary>
		/// <param name="characterId"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public bool SaveSessionKey(long characterId, string key)
		{
			using (var conn = this.GetConnection())
			using (var cmd = new UpdateCommand("UPDATE `characters` SET {0} WHERE `characterId` = @characterId", conn))
			{

				cmd.AddParameter("@characterId", characterId);
				cmd.Set("sessionKey", key);

				return cmd.Execute() == 1;
			}
		}
	}
}
