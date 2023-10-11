//--- Melia Script -----------------------------------------------------------
// Isolated
//--- Description -----------------------------------------------------------
// Quest to Talk to the isolated scholar.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(91194)]
public class Quest91194Script : QuestScript
{
	protected override void Load()
	{
		SetId(91194);
		SetName("Isolated");
		SetDescription("Talk to the isolated scholar");

		AddPrerequisite(new LevelPrerequisite(485));

		AddObjective("kill0", "Kill 20 Vubbe Rider(s) or Vubbe Warrior(s) or Vubbe Shaman(s)", new KillObjective(20, 59777, 59780, 59778));

		AddReward(new ExpReward(4200000000, 4200000000));
		AddReward(new ItemReward("Vis", 200000));

		AddDialogHook("EP15_1_ABBEY2_SQ3_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_F_ABBEY2_1_TRIGGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_ABBEY2_SQ3_DLG1", "EP15_1_ABBEY2_SQ3", "I will help", "Do as you wish"))
		{
			case 1:
				await dialog.Msg("EP15_1_ABBEY2_SQ3_DLG2");
				dialog.HideNPC("EP15_1_ABBEY2_SQ3_NPC");
				// Func/SCR_FOLLOWNPC_SQ3_NPC_SUMMON;
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

		// Func/FOLLOWNPC_SQ3_NPC_CANCEL;
		// Func/SCR_EP15_1_ABBEY2_SQ3_TRACK;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

