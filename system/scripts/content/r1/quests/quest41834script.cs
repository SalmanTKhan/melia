//--- Melia Script -----------------------------------------------------------
// Helping the Boy (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Laker Boy.
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

[QuestScript(41834)]
public class Quest41834Script : QuestScript
{
	protected override void Load()
	{
		SetId(41834);
		SetName("Helping the Boy (2)");
		SetDescription("Talk to the Laker Boy");

		AddPrerequisite(new LevelPrerequisite(395));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_3_SQ_1"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("F_3CMLAKE_27_3_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_3_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_3_SQ_2_DLG1", "F_3CMLAKE_27_3_SQ_2", "I will help you carry the Water Plants.", "It looks too heavy."))
		{
			case 1:
				// Func/FADEFUNC;
				dialog.HideNPC("F_3CMLAKE_27_3_NPC1");
				dialog.UnHideNPC("F_3CMLAKE_27_3_NPC2");
				dialog.UnHideNPC("F_3CMLAKE_27_3_SQ_2_NPC3");
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

		await dialog.Msg("F_3CMLAKE_27_3_SQ_2_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

