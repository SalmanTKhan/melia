//--- Melia Script -----------------------------------------------------------
// The Key to Persuasion
//--- Description -----------------------------------------------------------
// Quest to Talk to Vanessa Shaton.
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

[QuestScript(70041)]
public class Quest70041Script : QuestScript
{
	protected override void Load()
	{
		SetId(70041);
		SetName("The Key to Persuasion");
		SetDescription("Talk to Vanessa Shaton");

		AddPrerequisite(new LevelPrerequisite(155));
		AddPrerequisite(new CompletedPrerequisite("FARM49_3_MQ01"));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4495));

		AddDialogHook("FARM493_MQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("FARM493_MQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_3_MQ_02_1", "FARM49_3_MQ02", "Ask what you should do", "About Gord Shaton", "I don't want to get involved"))
		{
			case 1:
				await dialog.Msg("FARM49_3_MQ_02_2");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM49_3_MQ_02_5");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("FARM49_3_MQ02_ITEM", 1))
		{
			character.Inventory.RemoveItem("FARM49_3_MQ02_ITEM", 1);
			await dialog.Msg("FARM49_3_MQ_02_4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

