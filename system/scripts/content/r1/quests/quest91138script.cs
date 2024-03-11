//--- Melia Script -----------------------------------------------------------
// Ominous Red Crystal (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(91138)]
public class Quest91138Script : QuestScript
{
	protected override void Load()
	{
		SetId(91138);
		SetName("Ominous Red Crystal (1)");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new LevelPrerequisite(470));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE1_MQ_4"));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_1_PAJAUTA1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_2_1_PAJAUTA1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_2_DCASTLE1_MQ_5_DLG1", "EP14_2_DCASTLE1_MQ_5", "I am ready.", "I will come after doing something else"))
		{
			case 1:
				await dialog.Msg("EP14_2_DCASTLE1_MQ_5_DLG2");
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

		if (character.Inventory.HasItem("EP14_2_DCASTLE1_MQ_5_ITEM1", 6))
		{
			character.Inventory.RemoveItem("EP14_2_DCASTLE1_MQ_5_ITEM1", 6);
			await dialog.Msg("EP14_2_DCASTLE1_MQ_5_DLG4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_2_DCASTLE1_MQ_6");
	}
}

