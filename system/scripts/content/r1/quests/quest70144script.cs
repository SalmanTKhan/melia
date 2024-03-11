//--- Melia Script -----------------------------------------------------------
// True Colors Revealed
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Natasha.
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

[QuestScript(70144)]
public class Quest70144Script : QuestScript
{
	protected override void Load()
	{
		SetId(70144);
		SetName("True Colors Revealed");
		SetDescription("Talk to Hunter Natasha");

		AddPrerequisite(new LevelPrerequisite(179));
		AddPrerequisite(new CompletedPrerequisite("THORN39_3_MQ04"));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5370));

		AddDialogHook("THORN393_MQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("THORN393_MQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_3_MQ_05_1", "THORN39_3_MQ05", "I'll try to look for them", "Reject since you don't feel good about it"))
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

		if (character.Inventory.HasItem("THORN39_3_MQ05_ITEM", 1))
		{
			character.Inventory.RemoveItem("THORN39_3_MQ05_ITEM", 1);
			await dialog.Msg("THORN39_3_MQ_05_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

