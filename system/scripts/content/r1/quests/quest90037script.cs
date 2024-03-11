//--- Melia Script -----------------------------------------------------------
// Need to Look in Other Places
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Asel.
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

[QuestScript(90037)]
public class Quest90037Script : QuestScript
{
	protected override void Load()
	{
		SetId(90037);
		SetName("Need to Look in Other Places");
		SetDescription("Talk to Dievdirbys Asel");

		AddPrerequisite(new LevelPrerequisite(245));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_1_SQ_6"));

		AddObjective("kill0", "Kill 10 Brown Stoulet Archer(s) or Green Socket(s) or Gray Stoulet(s)", new KillObjective(10, 57919, 57926, 57915));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 9065));

		AddDialogHook("KATYN_45_1_AJEL2", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_1_OWL2_ENT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_1_SQ_7_ST", "KATYN_45_1_SQ_7", "You're not in good condition; I'll help you.", "I need to go, I have urgent matters to tend to."))
		{
			case 1:
				await dialog.Msg("KATYN_45_1_SQ_7_AG");
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

		dialog.UnHideNPC("KATYN_45_1_AJEL3");
		await dialog.Msg("FadeOutIN/2000");
		dialog.HideNPC("KATYN_45_1_AJEL2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

