//--- Melia Script -----------------------------------------------------------
// Helping the Boy (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Laker Boy.
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

[QuestScript(41835)]
public class Quest41835Script : QuestScript
{
	protected override void Load()
	{
		SetId(41835);
		SetName("Helping the Boy (3)");
		SetDescription("Talk to the Laker Boy");

		AddPrerequisite(new LevelPrerequisite(395));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_27_3_SQ_2"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("F_3CMLAKE_27_3_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_27_3_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_27_3_SQ_3_DLG1", "F_3CMLAKE_27_3_SQ_3", "I can help, sure.", "Let's wait."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_27_3_SQ_3_DLG2");
				dialog.UnHideNPC("F_3CMLAKE_27_3_SQ_3_NPC1");
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

		if (character.Inventory.HasItem("F_3CMLAKE_27_3_SQ_3_ITEM", 9))
		{
			character.Inventory.RemoveItem("F_3CMLAKE_27_3_SQ_3_ITEM", 9);
			await dialog.Msg("F_3CMLAKE_27_3_SQ_3_DLG4");
			dialog.HideNPC("F_3CMLAKE_27_3_SQ_3_NPC1");
			dialog.HideNPC("F_3CMLAKE_27_3_SQ_2_NPC1");
			dialog.HideNPC("F_3CMLAKE_27_3_SQ_2_NPC3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE_27_3_SQ_4");
	}
}

