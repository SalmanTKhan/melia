//--- Melia Script -----------------------------------------------------------
// Threat at Poslinkis Forest (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Owl Chief Sculpture.
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

[QuestScript(19420)]
public class Quest19420Script : QuestScript
{
	protected override void Load()
	{
		SetId(19420);
		SetName("Threat at Poslinkis Forest (1)");
		SetDescription("Talk to the Owl Chief Sculpture");

		AddPrerequisite(new LevelPrerequisite(112));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2688));

		AddDialogHook("KATYN13_1_OWLBOSS", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN13_1_OWLJUNIOR3_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN13_ADDQUEST5_01", "KATYN13_NEWSUB_01", "I'll go take a look", "Everything will be alright"))
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

		await dialog.Msg("KATYN13_ADDQUEST5_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

