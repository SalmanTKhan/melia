using System;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Items;
using Melia.Zone.World.Actors.Monsters;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.World.Actors.CombatEntities.Components;

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
	[ScriptableFunction("SCR_USE_ACHIEVE_BOX")]
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
	[ScriptableFunction("SCR_USE_ChallengeExpertModeCountUp")]
	public ItemUseResult SCR_USE_ChallengeExpertModeCountUp(Character character, Item item, string strArg, float numArg1, float numArg2)
	{
		character.ModifyAccountProperty(PropertyName.ChallengeMode_HardMode_EnableEntryCount, 1);
		character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "!@#$ChallengeExpertModeReset_MSG2#@!");

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
	[ScriptableFunction("SCR_USE_SUMMONORB_FRIEND")]
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
		//SetHookMsgOwner(mob, self);
		//SetLifeTime(mon, 180);
		//RunSimpleAI(mob, 'alche_summon');

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
	[ScriptableFunction("SCR_USE_SUMMONORB_ENEMY")]
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
		//SetHookMsgOwner(mob, self);
		//SetLifeTime(mon, 180);
		//RunSimpleAI(mob, 'alche_summon');

		return ItemUseResult.Okay;
	}
}
