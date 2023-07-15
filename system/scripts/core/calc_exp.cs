﻿//--- Melia Script ----------------------------------------------------------
// Exp Calculation Functions
//--- Description -----------------------------------------------------------
// Functions that primarily calculate exp given by monsters.
//---------------------------------------------------------------------------

using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;

public class ExpCalculationsFunctionsScript : GeneralScript
{
	/// <summary>
	/// Returns the monster's exp penalty given to a character.
	/// </summary>
	/// <param name="monster"></param>
	/// <returns></returns>
	[ScriptableFunction("SCR_Get_MON_ExpPenalty")]
	[ScriptableFunction("SCR_Get_MON_ClassExpPenalty")]
	public float SCR_Get_MON_ExpPenalty(Mob monster, Character character)
	{
		var levelDiff = character.Level - monster.Level;
		var expPenalty = 1f;

		if (levelDiff >= 10)
			expPenalty = .02f;
		else if (levelDiff == 9)
			expPenalty = .15f;
		else if (levelDiff == 8)
			expPenalty = .36f;
		else if (levelDiff == 7)
			expPenalty = .68f;
		else if (levelDiff == 6)
			expPenalty = .88f;
		else if (levelDiff >= -5 && levelDiff <= 5)
			expPenalty = 1f;
		else if (levelDiff == -6)
			expPenalty = .81f;
		else if (levelDiff == -7)
			expPenalty = .62f;
		else if (levelDiff == -8)
			expPenalty = .43f;
		else if (levelDiff == -9)
			expPenalty = .24f;
		else if (levelDiff <= -10)
			expPenalty = .05f;

		return expPenalty;
	}
}