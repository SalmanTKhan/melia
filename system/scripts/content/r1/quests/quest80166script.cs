//--- Melia Script -----------------------------------------------------------
// Before the Demon King Arrives (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Medena.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(80166)]
public class Quest80166Script : QuestScript
{
	protected override void Load()
	{
		SetId(80166);
		SetName("Before the Demon King Arrives (3)");
		SetDescription("Talk to Kupole Medena");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "LIMESTONE_52_5_MQ_5_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(301));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_5_MQ_4"));

		AddObjective("kill0", "Kill 1 Lavenzard", new KillObjective(1, MonsterId.Boss_Rambandgad));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 13846));

		AddDialogHook("LIMESTONECAVE_52_5_MEDENA_AI", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONE_52_5_MQ_5_EVIL_DEVICE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_5_MQ_5_start", "LIMESTONE_52_5_MQ_5", "Let's go.", "I'm scared."))
		{
			case 1:
				// Func/LIMESTONE_52_5_REENTER_RUN;
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		// Func/LIMESTONE_52_5_MQ_7_END;
		dialog.HideNPC("LIMESTONE_52_5_MQ_6_ANTIEVIL_1");
		dialog.UnHideNPC("LIMESTONE_52_5_MQ_6_ANTIEVIL_2");
		dialog.HideNPC("LIMESOTNE_52_5_WALL");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

