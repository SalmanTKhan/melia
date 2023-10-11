//--- Melia Script -----------------------------------------------------------
// Hidden Farming Equipment
//--- Description -----------------------------------------------------------
// Quest to Talk to Farmer Deluma.
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

[QuestScript(60180)]
public class Quest60180Script : QuestScript
{
	protected override void Load()
	{
		SetId(60180);
		SetName("Hidden Farming Equipment");
		SetDescription("Talk to Farmer Deluma");

		AddPrerequisite(new LevelPrerequisite(92));

		AddReward(new ExpReward(49142, 49142));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("Vis", 1840));

		AddDialogHook("FARM471_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FARM471_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM471_RP_1_1", "FARM471_RP_1", "I'll try to find them", "Disregard"))
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

		await dialog.Msg("FARM471_RP_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

