//--- Melia Script -----------------------------------------------------------
// No Freedom (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Kupole Vita.
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

[QuestScript(30021)]
public class Quest30021Script : QuestScript
{
	protected override void Load()
	{
		SetId(30021);
		SetName("No Freedom (1)");
		SetDescription("Talk with Kupole Vita");

		AddPrerequisite(new LevelPrerequisite(194));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_38_1_SQ_04"));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 6014));

		AddDialogHook("CATACOMB_38_1_NPC_02", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_38_1_NPC_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_38_1_SQ_05_select", "CATACOMB_38_1_SQ_05", "I'll look for the spirit again", "I can only help so much"))
		{
			case 1:
				dialog.UnHideNPC("CATACOMB_38_1_NPC_03");
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

		if (character.Inventory.HasItem("CATACOMB_38_1_SQ_05_ITEM", 6))
		{
			character.Inventory.RemoveItem("CATACOMB_38_1_SQ_05_ITEM", 6);
			await dialog.Msg("CATACOMB_38_1_SQ_05_succ");
			dialog.HideNPC("CATACOMB_38_1_OBJ_02");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_38_1_SQ_06");
	}
}

