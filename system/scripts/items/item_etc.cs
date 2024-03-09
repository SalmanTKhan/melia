using System;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Items;
using Melia.Zone.World.Actors.Monsters;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.World.Actors.CombatEntities.Components;
using static Melia.Zone.Scripting.Shortcuts;

public class ItemEtcScripts : GeneralScript
{
	/// <summary>
	/// Unlocks an achievement by adding 1 achievement point specified by the item.
	/// </summary>
	/// <param name="character"></param>
	/// <param name="item"></param>
	/// <param name="strArg"></param>
	/// <param name="numArg1"></param>
	/// <param name="numArg2"></param>
	/// <returns></returns>
	[ScriptableFunction]
	public ItemUseResult SCR_USE_ACHIEVE_BOX(Character character, Item item, string strArg, float numArg1, float numArg2)
	{
		var achievementPointName = strArg;

		character.Achievements.AddAchievementPoints(achievementPointName, 1);

		return ItemUseResult.Okay;
	}

	[ScriptableFunction]
	public ItemUseResult SCR_USE_ITEM_ADD_CHAT_EMOTICON(Character character, Item item, string strArg, float numArg1, float numArg2)
	{
		if (!ZoneServer.Instance.Data.ChatEmoticonDb.TryFind(strArg, out var data))
			return ItemUseResult.Fail;

		character.SetAccountProperty($"HaveEmoticon_{data.Id}", 1);
		character.AddonMessage(AddonMessage.ADD_CHAT_EMOTICON);

		return ItemUseResult.Okay;
	}

	/// <summary>
	/// Increase an entry count for Challenge Mode: Division Singularity?
	/// </summary>
	/// <param name="character"></param>
	/// <param name="item"></param>
	/// <param name="strArg"></param>
	/// <param name="numArg1"></param>
	/// <param name="numArg2"></param>
	/// <returns></returns>
	[ScriptableFunction]
	public ItemUseResult SCR_USE_ChallengeExpertModeCountUp(Character character, Item item, string strArg, float numArg1, float numArg2)
	{
		character.ModifyAccountProperty(PropertyName.ChallengeMode_HardMode_EnableEntryCount, 1);
		character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, ScpArgMsg("ChallengeExpertModeReset_MSG2"));

		return ItemUseResult.Okay;
	}

	/// <summary>
	/// Summons a friendly monster
	/// </summary>
	/// <param name="character"></param>
	/// <param name="item"></param>
	/// <param name="strArg"></param>
	/// <param name="numArg1"></param>
	/// <param name="numArg2"></param>
	/// <returns></returns>
	[ScriptableFunction]
	public ItemUseResult SCR_USE_SUMMONORB_FRIEND(Character character, Item item, string strArg, float numArg1, float numArg2)
	{
		if (!ZoneServer.Instance.Data.MonsterDb.TryFind(strArg, out var monsterData))
			return ItemUseResult.Fail;
		var monster = new Mob(monsterData.Id, MonsterType.Friendly);

		monster.Faction = FactionType.Summon;
		monster.Position = character.Position;

		monster.OwnerHandle = character.Handle;
		monster.Components.Add(new LifeTimeComponent(monster, TimeSpan.FromSeconds(180)));
		monster.Components.Add(new MovementComponent(monster));
		monster.Components.Add(new AiComponent(monster, "AlcheSummon"));

		character.Map.AddMonster(monster);

		return ItemUseResult.Okay;
	}

	/// <summary>
	/// Summons an unfriendly monster
	/// </summary>
	/// <param name="character"></param>
	/// <param name="item"></param>
	/// <param name="strArg"></param>
	/// <param name="numArg1"></param>
	/// <param name="numArg2"></param>
	/// <returns></returns>
	[ScriptableFunction]
	public ItemUseResult SCR_USE_SUMMONORB_ENEMY(Character character, Item item, string strArg, float numArg1, float numArg2)
	{
		if (!ZoneServer.Instance.Data.MonsterDb.TryFind(strArg, out var monsterData))
			return ItemUseResult.Fail;
		var monster = new Mob(monsterData.Id, MonsterType.Mob);

		monster.Faction = FactionType.Summon;
		monster.Position = character.Position;

		monster.Components.Add(new LifeTimeComponent(monster, TimeSpan.FromSeconds(180)));
		monster.Components.Add(new MovementComponent(monster));
		monster.Components.Add(new AiComponent(monster, "AlcheSummon"));

		character.Map.AddMonster(monster);

		return ItemUseResult.Okay;
	}

	/// <summary>
	/// Use hair color spray
	/// </summary>
	/// <param name="character"></param>
	/// <param name="item"></param>
	/// <param name="strArg"></param>
	/// <param name="numArg1"></param>
	/// <param name="numArg2"></param>
	/// <returns></returns>
	[ScriptableFunction]
	public ItemUseResult SCR_USE_ITEM_HAIRCOLOR(Character character, Item item, string strArg, float numArg1, float numArg2)
	{
		var etcColor = $"HairColor_{strArg}";

		if (character.EtcProperties[etcColor] == 1)
		{
			character.AddonMessage(AddonMessage.NOTICE_Dm_Exclaimation, ScpArgMsg("HairColorExist"), 2);
			return ItemUseResult.Fail;
		}

		SetAllowHairColor(character, etcColor);

		character.AddonMessage(AddonMessage.HAIR_COLOR_CHANGE, item.Data.ClassName, 100);

		return ItemUseResult.Okay;
	}

	public static bool HaveHairColor(Character character, string color)
	{
		var etc = character.EtcProperties;
		var nowAllowedColor = etc.GetString("AllowedHairColor");

		if (nowAllowedColor.Contains(color) || etc[$"HairColor_{color}"] == 1)
			return true;
		return false;
	}

	public static void SetAllowHairColor(Character character, string newColor)
	{
		string[] colorTable = { "default", "black", "blue", "white", "pink", "blond", "red", "green", "gray", "lightsalmon", "purple", "orange", "midnightblue" };
		var index = -1;
		for (var i = 0; i < colorTable.Length; i++)
		{
			if (newColor == colorTable[i])
			{
				index = i;
				break;
			}
		}

		if (index == -1)
			return;

		var etcColor = $"HairColor_{colorTable[index]}";
		var etc = character.EtcProperties;

		if (etc[etcColor] != 1)
			character.SetEtcProperty(etcColor, 1);
	}

	public static void SetAllowHairColor(Character character, string color, string achieveName)
	{
		var etc = character.EtcProperties;
		var etcPropName = "AchieveReward_" + achieveName;

		if (etc == null || etc[etcPropName] == 1)
		{
			return;
		}

		if (HaveHairColor(character, color))
		{
			character.SetEtcProperty(etcPropName, 1);
			character.SystemMessage("GainAchieveHairBefore");
			character.AddonMessage("ACHIEVE_REWARD");
			return;
		}

		SetAllowHairColor(character, color);

		character.SystemMessage($"GainAchieveHair{color.ToUpperInvariant()[0] + color.Substring(1)}");
		character.AddonMessage("ACHIEVE_REWARD", "", 0);
	}

	[ScriptableFunction]
	public ItemUseResult SCR_USE_STRING_GIVE_ITEM_NUMBER_SPLIT(Character character, Item item, string strArg, float numArg1, float numArg2)
	{
		var items = ParseItems(strArg);

		foreach (var parsedItem in items)
			character.AddItem(parsedItem.Key, parsedItem.Value);

		return ItemUseResult.Okay;
	}

	public ItemUseResult SCR_USE_STRING_GIVE_ITEM_NUMBER_SPLIT_COLLECTION(Character character, Item item, string strArg, float numArg1, float numArg2)
	{
		// Collections not implemented.
		return ItemUseResult.Fail;
	}

	public ItemUseResult SCR_USE_DRESS_ROOM_COLLECTION_GET(Character character, Item item, string strArg, float numArg1, float numArg2)
	{
		// Collections not implemented.
		return ItemUseResult.Fail;
	}
}
