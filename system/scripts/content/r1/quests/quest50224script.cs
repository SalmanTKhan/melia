//--- Melia Script -----------------------------------------------------------
// Maven's Wishes(3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Lintas.
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

[QuestScript(50224)]
public class Quest50224Script : QuestScript
{
	protected override void Load()
	{
		SetId(50224);
		SetName("Maven's Wishes(3)");
		SetDescription("Talk to Priest Lintas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "BRACKEN43_4_SQ3_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(316));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_4_SQ2"));

		AddObjective("kill0", "Kill 1 Gosal", new KillObjective(1, MonsterId.Boss_Gosal_Q1));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("BRACKEN434_SUBQ1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN434_SUBQ1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN434_SQ3_START1", "BRACKEN43_4_SQ3", "Agree to go and find the Monument", "Say that you will help later"))
		{
			case 1:
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

		await dialog.Msg("BRACKEN434_SQ3_SUCC1");
		dialog.UnHideNPC("BRACKEN434_SUBQ_STELE_NPC5");
		dialog.UnHideNPC("BRACKEN434_SUBQ_STELE_NPC4");
		dialog.UnHideNPC("BRACKEN434_OBJ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

