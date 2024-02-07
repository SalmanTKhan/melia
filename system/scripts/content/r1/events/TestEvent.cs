//--- Melia Script -----------------------------------------------------------
// Testing Events
//--- Description -----------------------------------------------------------
// A testing ground for in-game events
//---------------------------------------------------------------------------

using System;
using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class TestEventScript : GameEventScript
{
	public override void Load()
	{
		SetId("melia_test_event");
		SetName(L("Test Event"));
	}

	public override void AfterLoad()
	{
		ScheduleEvent(DateTime.Parse("2024-01-24 00:00"), TimeSpan.FromDays(3));
		ScheduleEvent(DateTime.Parse("2024-02-07 00:00"), TimeSpan.FromDays(3));
		ScheduleEvent(DateTime.Parse("2024-03-14 00:00"), TimeSpan.FromDays(3));
	}

	protected override void OnStart()
	{
		AddGlobalBuff(BuffId.GoldenFishEvent, 100, 0);
		//AddGlobalBonus(GlobalBonusStat.LevelUpAp, 2);
	}

	protected override void OnEnd()
	{
		RemoveGlobalBuffs();
		//RemoveGlobalBonuses();
	}
}
