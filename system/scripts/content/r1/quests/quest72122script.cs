//--- Melia Script -----------------------------------------------------------
// A Leaf Grown by the Lake
//--- Description -----------------------------------------------------------
// Quest to Talk to Leonardas.
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

[QuestScript(72122)]
public class Quest72122Script : QuestScript
{
	protected override void Load()
	{
		SetId(72122);
		SetName("A Leaf Grown by the Lake");
		SetDescription("Talk to Leonardas");

		AddPrerequisite(new LevelPrerequisite(336));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE261_SQ15"));

		AddObjective("collect0", "Collect 18 Lakeland Leaves(s)", new CollectItemObjective("3CMLAKE262_SQ08_ITEM", 18));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15792));

		AddDialogHook("3CMLAKE_LEONARDAS", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_LEONARDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE262_SQ08_DLG01", "F_3CMLAKE262_SQ08", "Alright", "I'll help you later."))
		{
			case 1:
				await dialog.Msg("3CMLAKE262_SQ08_DLG02");
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

		if (character.Inventory.HasItem("3CMLAKE262_SQ08_ITEM", 18))
		{
			character.Inventory.RemoveItem("3CMLAKE262_SQ08_ITEM", 18);
			await dialog.Msg("3CMLAKE262_SQ08_DLG04");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

