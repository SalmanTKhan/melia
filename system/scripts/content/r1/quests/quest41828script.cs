//--- Melia Script -----------------------------------------------------------
// Monster Leader Operation (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Brockal Himil's Apprentice.
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

[QuestScript(41828)]
public class Quest41828Script : QuestScript
{
	protected override void Load()
	{
		SetId(41828);
		SetName("Monster Leader Operation (2)");
		SetDescription("Talk to Brockal Himil's Apprentice");

		AddPrerequisite(new LevelPrerequisite(391));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_2_SQ_6"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("F_3CMLAKE_27_2_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_2_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_2_SQ_7_DLG1", "F_3CMLAKE_27_2_SQ_7", "I'll help you with the bombs.", "I really need some rest, sorry."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_27_2_SQ_7_DLG2");
				// Func/FADEFUNC;
				dialog.HideNPC("F_3CMLAKE_27_2_NPC2");
				dialog.UnHideNPC("F_3CMLAKE_27_2_SQ_7_HNPC2");
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

		await dialog.Msg("F_3CMLAKE_27_2_SQ_7_DLG4");
		dialog.HideNPC("F_3CMLAKE_27_2_SQ_7_HNPC2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE_27_2_SQ_8");
	}
}

