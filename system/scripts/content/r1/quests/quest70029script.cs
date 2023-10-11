//--- Melia Script -----------------------------------------------------------
// Intentional Failed Harvest
//--- Description -----------------------------------------------------------
// Quest to Talk to Tenant Farmer Charlotte.
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

[QuestScript(70029)]
public class Quest70029Script : QuestScript
{
	protected override void Load()
	{
		SetId(70029);
		SetName("Intentional Failed Harvest");
		SetDescription("Talk to Tenant Farmer Charlotte");

		AddPrerequisite(new LevelPrerequisite(152));
		AddPrerequisite(new CompletedPrerequisite("FARM49_2_MQ01"));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4408));

		AddDialogHook("FARM492_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("FARM492_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_2_SQ_03_1", "FARM49_2_SQ03", "Ask her what's the matter and help", "About the crops at the farm", "You don't feel good about it so avoid it"))
		{
			case 1:
				await dialog.Msg("FARM49_2_SQ_03_2");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM49_2_SQ_03_3");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM49_2_SQ_03_5");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

