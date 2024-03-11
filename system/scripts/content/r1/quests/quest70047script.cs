//--- Melia Script -----------------------------------------------------------
// Managing the Steward's People
//--- Description -----------------------------------------------------------
// Quest to Talk to Steward Valen.
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

[QuestScript(70047)]
public class Quest70047Script : QuestScript
{
	protected override void Load()
	{
		SetId(70047);
		SetName("Managing the Steward's People");
		SetDescription("Talk to Steward Valen");

		AddPrerequisite(new LevelPrerequisite(155));
		AddPrerequisite(new CompletedPrerequisite("FARM49_3_SQ01"));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4495));

		AddDialogHook("FARM493_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FARM493_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_3_SQ_02_1", "FARM49_3_SQ02", "I will find the pocket that contains the medicine", "Sorry, I'm busy"))
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

		if (character.Inventory.HasItem("FARM49_3_SQ02_ITEM", 7))
		{
			character.Inventory.RemoveItem("FARM49_3_SQ02_ITEM", 7);
			await dialog.Msg("FARM49_3_SQ_02_4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

