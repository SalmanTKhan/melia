//--- Melia Script -----------------------------------------------------------
// Supply Soldier's Favor (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Supply Soldier in the Eastern Woods.
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

[QuestScript(1041)]
public class Quest1041Script : QuestScript
{
	protected override void Load()
	{
		SetId(1041);
		SetName("Supply Soldier's Favor (1)");
		SetDescription("Talk to the Supply Soldier in the Eastern Woods");

		AddPrerequisite(new LevelPrerequisite(7));

		AddObjective("collect0", "Collect 6 Weaver Claw(s)", new CollectItemObjective("SIAUL_EAST_REQUEST4_Claw", 6));
		AddDrop("SIAUL_EAST_REQUEST4_Claw", 10f, "Weaver");

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("Vis", 91));

		AddDialogHook("SIAUL_EAST_SOLDIER5", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_EAST_SOLDIER5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_EAST_REQUEST4_dlg1", "SIAUL_EAST_REQUEST4", "I'll help you collect Weaver Claws", "Cancel"))
		{
			case 1:
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

		if (character.Inventory.HasItem("SIAUL_EAST_REQUEST4_Claw", 6))
		{
			character.Inventory.RemoveItem("SIAUL_EAST_REQUEST4_Claw", 6);
			await dialog.Msg("SIAUL_EAST_REQUEST4_dlg3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAUL_EAST_REQUEST5");
	}
}

