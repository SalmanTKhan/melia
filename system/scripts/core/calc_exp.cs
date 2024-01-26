//--- Melia Script ----------------------------------------------------------
// Exp Calculation Functions
//--- Description -----------------------------------------------------------
// Functions that primarily calculate exp given by monsters.
//---------------------------------------------------------------------------

using System;
using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;
using Melia.Zone.World.Dungeons;

public class ExpCalculationsFunctionsScript : GeneralScript
{

	/// <summary>
	/// Official exp ratio formula
	/// </summary>
	/// <param name="monster"></param>
	/// <param name="character"></param>
	/// <returns></returns>
	[ScriptableFunction("GET_EXP_RATIO")]
	public float GET_EXP_RATIO(Mob monster, Character character)
	{
		var characterLv = character.Level;
		var monsterLv = monster.Level;
		var value = 1.0f;

		if (monster.Buffs.Has(BuffId.SuperExp))
			value = 500.0f;

		var standardLevel = 30;
		var levelGap = Math.Abs(characterLv - monsterLv);

		if (levelGap > standardLevel)
		{
			var penaltyRatio = characterLv < monsterLv ? 0.05f : 0.02f;
			var lvRatio = 1.0f - ((levelGap - standardLevel) * penaltyRatio);
			value *= lvRatio;
		}

		return Math.Min(0, value);
	}

	/// <summary>
	/// Official instance dungeon exp ratio formula
	/// </summary>
	/// <param name="instanceDungeon"></param>
	/// <param name="character"></param>
	/// <returns></returns>
	/// <remarks>Disabled Attributed because Instance Dungeons aren't implemented.</remarks>
	//[ScriptableFunction("GET_EXP_RATIO_INDUN")]
	public float GET_EXP_RATIO_INDUN(InstanceDungeon instanceDungeon, Character character)
	{
		var characterLv = character.Level;
		var instanceDungeonLv = instanceDungeon.Level;
		var value = 1.0f;

		var standardLevel = 80;
		var levelGap = Math.Abs(characterLv - instanceDungeonLv);

		if (levelGap > standardLevel)
		{
			var penaltyRatio = characterLv < instanceDungeonLv ? 0.05f : 0.05f;
			var lvRatio = 1.0f - ((levelGap - standardLevel) * penaltyRatio);
			value *= lvRatio;
		}

		return Math.Min(0, value);
	}
}
