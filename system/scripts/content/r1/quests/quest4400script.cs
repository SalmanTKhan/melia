//--- Melia Script -----------------------------------------------------------
// An Endless Mission (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Commander Wallace.
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

[QuestScript(4400)]
public class Quest4400Script : QuestScript
{
	protected override void Load()
	{
		SetId(4400);
		SetName("An Endless Mission (3)");
		SetDescription("Talk to Commander Wallace");

		AddPrerequisite(new LevelPrerequisite(123));
		AddPrerequisite(new CompletedPrerequisite("THORN23_Q_6"));

		AddObjective("collect0", "Collect 14 Kepa Raider Sap(s)", new CollectItemObjective("THORN23_Sap_1", 14));
		AddDrop("THORN23_Sap_1", 10f, "raider");

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3075));

		AddDialogHook("THORN23_WALLACE", "BeforeStart", BeforeStart);
		AddDialogHook("THORN23_WALLACE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN23_Q_10_select1", "THORN23_Q_10", "Weird, but I'll carry out the task", "Make it clear that you're not a new recruit"))
		{
			case 1:
				await dialog.Msg("THORN23_Q_10_Q");
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

		if (character.Inventory.HasItem("THORN23_Sap_1", 14))
		{
			character.Inventory.RemoveItem("THORN23_Sap_1", 14);
			await dialog.Msg("THORN23_Q_10_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("THORN23_Q_12");
	}
}

