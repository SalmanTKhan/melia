//--- Melia Script -----------------------------------------------------------
// Halloween Demon Hunt (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Recovery Squad Adjutant.
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

[QuestScript(41815)]
public class Quest41815Script : QuestScript
{
	protected override void Load()
	{
		SetId(41815);
		SetName("Halloween Demon Hunt (1)");
		SetDescription("Talk to the Recovery Squad Adjutant");

		AddPrerequisite(new LevelPrerequisite(388));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_1_SQ_4"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("F_3CMLAKE_27_1_NPC2_3", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_1_NPC2_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_1_SQ_5_DLG1", "F_3CMLAKE_27_1_SQ_5", "Sure, I can help.", "I'll wait."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_27_1_SQ_5_DLG2");
				dialog.UnHideNPC("F_3CMLAKE_27_1_SQ_5_NPC1");
				dialog.UnHideNPC("F_3CMLAKE_27_1_SQ_5_NPC2");
				dialog.UnHideNPC("F_3CMLAKE_27_1_SQ_5_NPC3");
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

		await dialog.Msg("F_3CMLAKE_27_1_SQ_5_DLG4");
		dialog.HideNPC("F_3CMLAKE_27_1_SQ_5_NPC1");
		dialog.HideNPC("F_3CMLAKE_27_1_SQ_5_NPC2");
		dialog.HideNPC("F_3CMLAKE_27_1_SQ_5_NPC3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE_27_1_SQ_6");
	}
}

