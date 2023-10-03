using System.Collections.Generic;
using System.Linq;
using Melia.Shared.Data.Database;
using Melia.Zone.Network;
using Yggdrasil.Logging;

namespace Melia.Zone.World.Actors.Characters.Components
{
	/// <summary>
	/// Achievements
	/// </summary>
	public class AchievementComponent : CharacterComponent
	{
		private readonly Dictionary<int, bool> _achievements = new Dictionary<int, bool>();
		private readonly Dictionary<int, int> _achievementPoints = new Dictionary<int, int>();

		public AchievementComponent(Character character) : base(character)
		{
		}

		public int[] GetAchievements()
		{
			lock (_achievements)
			{
				return _achievements.Keys.ToArray();
			}
		}

		public int[] GetPointIds()
		{
			lock (_achievementPoints)
			{
				return _achievementPoints.Keys.ToArray();
			}
		}

		public int GetPoints(int pointId)
		{
			lock (_achievementPoints)
			{
				_achievementPoints.TryGetValue(pointId, out var points);
				return points;
			}
		}

		public bool HasAchievement(int achievementId)
		{
			lock (_achievements)
				if (_achievements.TryGetValue(achievementId, out var hasAchievement))
					return hasAchievement;
			return false;
		}

		/// <summary>
		/// Add achievement points
		/// </summary>
		/// <param name="achievementPoint"></param>
		/// <param name="points"></param>
		/// <param name="silently"></param>
		public void AddAchievementPoints(string achievementPoint, int points, bool silently = false)
		{
			if (!ZoneServer.Instance.Data.AchievementPointDb.TryFind(achievementPoint, out var pointData))
			{
				Log.Warning("AddAchievement: Achievement point not found with class name: {0}.", achievementPoint);
				return;
			}

			this.AddAchievementPoints(pointData.Id, points);

			if (!silently)
			{
				Send.ZC_ACHIEVE_POINT(this.Character, points, -1, -1);
				this.CheckAchievements(pointData);
			}
		}

		/// <summary>
		/// Add achievement points
		/// </summary>
		/// <param name="achievementPointId"></param>
		/// <param name="points"></param>
		public void AddAchievementPoints(int achievementPointId, int points)
		{
			lock (_achievementPoints)
			{
				if (_achievementPoints.ContainsKey(achievementPointId))
					_achievementPoints[achievementPointId] += points;
				else
					_achievementPoints.Add(achievementPointId, points);
			}
		}

		/// <summary>
		/// Add an achievement
		/// </summary>
		/// <param name="achievementId"></param>
		/// <param name="silently"></param>
		public void AddAchievement(int achievementId, bool silently = false)
		{
			if (!ZoneServer.Instance.Data.AchievementDb.TryFind(achievementId, out var achievement))
			{
				Log.Warning("AddAchievement: Achievement with id: {0} not found.", achievementId);
				return;
			}

			if (!ZoneServer.Instance.Data.AchievementPointDb.TryFind(achievement.PointName, out var pointData))
			{
				Log.Warning("AddAchievement: Achievement with id: {0} not found.", achievementId);
				return;
			}

			lock (_achievements)
				_achievements[achievementId] = true;

			if (!silently)
				Send.ZC_ACHIEVE_POINT(this.Character, pointData.Id, _achievementPoints[pointData.Id], achievement.Id);
		}

		/// <summary>
		/// Check if achievements are unlocked.
		/// </summary>
		/// <param name="pointData"></param>
		private void CheckAchievements(AchievementPointData pointData)
		{
			foreach (var possibleAchievements in ZoneServer.Instance.Data.AchievementDb.FindAll(a => a.PointName == pointData.ClassName))
			{
				if (this.HasAchievement(possibleAchievements.Id))
					continue;
				if (_achievementPoints[pointData.Id] >= possibleAchievements.PointCount)
				{
					this.AddAchievement(possibleAchievements.Id);
				}
			}
		}
	}
}
