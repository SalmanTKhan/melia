//--- Melia Script -----------------------------------------------------------
// Call for Help
//--- Description -----------------------------------------------------------
// Quest to Talk to the Injured Soldier.
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

[QuestScript(41813)]
public class Quest41813Script : QuestScript
{
	protected override void Load()
	{
		SetId(41813);
		SetName("Call for Help");
		SetDescription("Talk to the Injured Soldier");

		AddPrerequisite(new LevelPrerequisite(388));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_1_SQ_2"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("F_3CMLAKE_27_1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_1_NPC2_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_1_SQ_3_DLG1", "F_3CMLAKE_27_1_SQ_3", "I'll go get help.", "I don't want to leave you alone."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_27_1_SQ_3_DLG3");
				dialog.UnHideNPC("F_3CMLAKE_27_1_NPC2_2");
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

		await dialog.Msg("F_3CMLAKE_27_1_SQ_3_DLG4");
		dialog.HideNPC("F_3CMLAKE_27_1_NPC2_2");
		dialog.UnHideNPC("F_3CMLAKE_27_1_NPC2_3");
		dialog.HideNPC("F_3CMLAKE_27_1_NPC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE_27_1_SQ_4");
	}
}

