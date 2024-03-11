//--- Melia Script -----------------------------------------------------------
// Jonas' Medicine (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Merchant Davio.
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

[QuestScript(4440)]
public class Quest4440Script : QuestScript
{
	protected override void Load()
	{
		SetId(4440);
		SetName("Jonas' Medicine (1)");
		SetDescription("Talk to Merchant Davio");

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("ROKAS24_QB_6"));

		AddObjective("collect0", "Collect 10 Golden Piece(s)", new CollectItemObjective("ROKAS24_SUPP_02", 10));
		AddDrop("ROKAS24_SUPP_02", 10f, 401061, 401401, 401101, 401181);

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("ROKAS24_DABIO", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_PHARMACIST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_QB_13_select1", "ROKAS24_QB_13", "I will bring the gold", "About Jonas' Status", "I don't have a reason to give it to him"))
		{
			case 1:
				dialog.UnHideNPC("ROKAS_24_FLORIJONAS2");
				dialog.HideNPC("ROKAS_24_FLORIJONAS");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("ROKAS24_QB_13_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("ROKAS24_SUPP_02", 10))
		{
			character.Inventory.RemoveItem("ROKAS24_SUPP_02", 10);
			await dialog.Msg("ROKAS24_QB_13_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

