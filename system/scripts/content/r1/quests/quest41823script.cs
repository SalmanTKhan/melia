//--- Melia Script -----------------------------------------------------------
// Acquiring Resources
//--- Description -----------------------------------------------------------
// Quest to Talk to Brockal Himil.
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

[QuestScript(41823)]
public class Quest41823Script : QuestScript
{
	protected override void Load()
	{
		SetId(41823);
		SetName("Acquiring Resources");
		SetDescription("Talk to Brockal Himil");

		AddPrerequisite(new LevelPrerequisite(391));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_2_SQ_1"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("F_3CMLAKE_27_2_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_2_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_2_SQ_2_DLG1", "F_3CMLAKE_27_2_SQ_2", "I can help, sure.", "I'll wait."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_27_2_SQ_2_DLG2");
				dialog.UnHideNPC("F_3CMLAKE_27_2_SQ_2_HNPC1");
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

		if (character.Inventory.HasItem("F_3CMLAKE_27_2_SQ_2_ITEM2", 10))
		{
			character.Inventory.RemoveItem("F_3CMLAKE_27_2_SQ_2_ITEM2", 10);
			await dialog.Msg("F_3CMLAKE_27_2_SQ_2_DLG4");
			dialog.HideNPC("F_3CMLAKE_27_2_SQ_2_HNPC1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE_27_2_SQ_3");
	}
}

