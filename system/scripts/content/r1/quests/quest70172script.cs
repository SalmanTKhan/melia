//--- Melia Script -----------------------------------------------------------
// Where it Belongs
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Moheim.
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

[QuestScript(70172)]
public class Quest70172Script : QuestScript
{
	protected override void Load()
	{
		SetId(70172);
		SetName("Where it Belongs");
		SetDescription("Talk to Monk Moheim");

		AddPrerequisite(new LevelPrerequisite(183));
		AddPrerequisite(new CompletedPrerequisite("ABBEY39_4_MQ10"));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5673));

		AddDialogHook("ABBEY394_MQ_07", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY394_MQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY39_4_SQ_03_1", "ABBEY39_4_SQ03", "I'll try to look for them", "Decline"))
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

		if (character.Inventory.HasItem("ABBEY39_4_SQ03_ITEM", 7))
		{
			character.Inventory.RemoveItem("ABBEY39_4_SQ03_ITEM", 7);
			await dialog.Msg("ABBEY39_4_SQ_03_4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

