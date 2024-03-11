//--- Melia Script -----------------------------------------------------------
// Emergency (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Guardian Stone Statue.
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

[QuestScript(8435)]
public class Quest8435Script : QuestScript
{
	protected override void Load()
	{
		SetId(8435);
		SetName("Emergency (1)");
		SetDescription("Talk to the Guardian Stone Statue");

		AddPrerequisite(new LevelPrerequisite(86));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1720));

		AddDialogHook("ZACHA2F_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA2F_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA2F_SQ_03_01", "ZACHA2F_SQ_03", "I'll gather the magic", "I'll wait a little bit"))
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

		if (character.Inventory.HasItem("ZACHA2F_SQ_03_ITEM", 8))
		{
			character.Inventory.RemoveItem("ZACHA2F_SQ_03_ITEM", 8);
			await dialog.Msg("ZACHA2F_SQ_03_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

