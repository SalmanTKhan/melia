//--- Melia Script -----------------------------------------------------------
// Convincing Lord Ryudhas(3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Lord Ryudhas.
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

[QuestScript(70825)]
public class Quest70825Script : QuestScript
{
	protected override void Load()
	{
		SetId(70825);
		SetName("Convincing Lord Ryudhas(3)");
		SetDescription("Talk to Lord Ryudhas");

		AddPrerequisite(new LevelPrerequisite(319));
		AddPrerequisite(new CompletedPrerequisite("MAPLE23_2_SQ05"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 14674));

		AddDialogHook("MAPLE232_SQ_04", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE232_SQ_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE232_SQ_06_start", "MAPLE23_2_SQ06", "Say that you are more than willing to help", "Tell him to make his men do it"))
		{
			case 1:
				await dialog.Msg("MAPLE232_SQ_06_agree");
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

		if (character.Inventory.HasItem("MAPLE23_2_SQ06_ITEM2", 1))
		{
			character.Inventory.RemoveItem("MAPLE23_2_SQ06_ITEM2", 1);
			await dialog.Msg("MAPLE232_SQ_06_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

