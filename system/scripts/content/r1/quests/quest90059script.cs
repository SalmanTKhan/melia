//--- Melia Script -----------------------------------------------------------
// Suppressing Sculpture
//--- Description -----------------------------------------------------------
// Quest to Talk to Sculptor Tesla.
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

[QuestScript(90059)]
public class Quest90059Script : QuestScript
{
	protected override void Load()
	{
		SetId(90059);
		SetName("Suppressing Sculpture");
		SetDescription("Talk to Sculptor Tesla");

		AddPrerequisite(new LevelPrerequisite(253));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_3_SQ_4"));

		AddDialogHook("JOB_DIEVDIRBYS2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_3_AJEL3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_3_SQ_5_ST", "KATYN_45_3_SQ_5", "Give me the statue.", "Please wait a bit"))
		{
			case 1:
				dialog.HideNPC("KATYN_45_3_AJEL3");
				dialog.UnHideNPC("KATYN_45_3_AJEL4");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("KATYN_45_3_SQ_5_SU");
		dialog.HideNPC("KATYN_45_3_AJEL3");
		dialog.HideNPC("KATYN_45_3_SCULPT3");
		await dialog.Msg("FadeOutIN/2000");
		dialog.UnHideNPC("KATYN_45_3_SCULPT2");
		dialog.UnHideNPC("KATYN_45_3_AJEL4");
		dialog.UnHideNPC("KATYN_45_3_SCULPT");
		await dialog.Msg("BalloonText/KATYN_45_3_SQ_5_SU2/3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

