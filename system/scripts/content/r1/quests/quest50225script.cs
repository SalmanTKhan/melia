//--- Melia Script -----------------------------------------------------------
// Maven's Wishes(5)
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

[QuestScript(50225)]
public class Quest50225Script : QuestScript
{
	protected override void Load()
	{
		SetId(50225);
		SetName("Maven's Wishes(5)");
		SetDescription("Talk to Priest Lintas");

		AddPrerequisite(new LevelPrerequisite(316));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_4_SQ3_1"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("BRACKEN434_SUBQ1_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN434_SUBQ1_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_4_SQ4_START1", "BRACKEN43_4_SQ4", "Go with Priest Lintas to find the Monument", "Leave him to go and find the Monument on his own"))
		{
			case 1:
				// Func/BRACKEN434_SUBQ4_AGREE;
				dialog.HideNPC("BRACKEN434_SUBQ1_NPC2");
				await dialog.Msg("FadeOutIN/1000");
				dialog.UnHideNPC("BRACKEN434_SUBQ4_HIDDEN3");
				dialog.UnHideNPC("BRACKEN434_SUBQ4_HIDDEN4");
				dialog.UnHideNPC("BRACKEN434_SUBQ4_HIDDEN5");
				dialog.UnHideNPC("BRACKEN434_SUBQ4_HIDDEN6");
				dialog.UnHideNPC("BRACKEN434_SUBQ4_HIDDEN1");
				dialog.UnHideNPC("BRACKEN434_SUBQ4_HIDDEN2");
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

		await dialog.Msg("BRACKEN43_4_SQ4_SUCC1");
		// Func/BRACKEN434_SUBQ4_COMPLETE;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

