//--- Melia Script -----------------------------------------------------------
// Red Bracken
//--- Description -----------------------------------------------------------
// Quest to Talk to Edmundas.
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

[QuestScript(91168)]
public class Quest91168Script : QuestScript
{
	protected override void Load()
	{
		SetId(91168);
		SetName("Red Bracken");
		SetDescription("Talk to Edmundas");

		AddPrerequisite(new LevelPrerequisite(480));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY1_3"));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY1_AD3", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_FABBEY1_AD3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_F_ABBEY1_4_DLG1", "EP15_1_F_ABBEY1_4", "Do you know about the Beholder?", "Why are you here?", "I'm not interested in anything other that the Beholder."))
		{
			case 1:
				await dialog.Msg("EP15_1_F_ABBEY1_4_DLG3");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("EP15_1_F_ABBEY1_4_DLG2");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("EP15_1_FABBEY1_MQ_4_ITEM1", 8))
		{
			character.Inventory.RemoveItem("EP15_1_FABBEY1_MQ_4_ITEM1", 8);
			await dialog.Msg("EP15_1_F_ABBEY1_4_DLG5");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_1_F_ABBEY1_5");
	}
}

