//--- Melia Script -----------------------------------------------------------
// Different Circumstances (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Tadas.
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

[QuestScript(60411)]
public class Quest60411Script : QuestScript
{
	protected override void Load()
	{
		SetId(60411);
		SetName("Different Circumstances (1)");
		SetDescription("Talk to Tadas");

		AddPrerequisite(new LevelPrerequisite(401));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE96_MQ_TADAS_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE96_MQ_TADAS_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE96_MQ_1_1", "CASTLE96_MQ_1", "Alright, I'll help you", "You've got hands right? Why don't you do it?"))
		{
			case 1:
				await dialog.Msg("CASTLE96_MQ_1_1_1");
				await dialog.Msg("FadeOutIN/3000");
				dialog.HideNPC("CASTLE96_MQ_TADAS_NPC_1");
				dialog.UnHideNPC("CASTLE96_MQ_WOLKE_NPC");
				dialog.UnHideNPC("CASTLE96_MQ_NERGUI_NPC");
				dialog.UnHideNPC("CASTLE96_MQ_TADAS_NPC_2");
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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

		await dialog.Msg("CASTLE96_MQ_1_3");
		// Func/SCR_CASTLE96_MQ_1_RUN_NPC_DLG_1;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

