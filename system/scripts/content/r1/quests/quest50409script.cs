//--- Melia Script -----------------------------------------------------------
// The City Under Threat (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Wizard Nidia.
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

[QuestScript(50409)]
public class Quest50409Script : QuestScript
{
	protected override void Load()
	{
		SetId(50409);
		SetName("The City Under Threat (3)");
		SetDescription("Talk to Wizard Nidia");

		AddPrerequisite(new LevelPrerequisite(387));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_3_SQ_06"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 2));

		AddDialogHook("NICO813_SUBQ_NPC2_3", "BeforeStart", BeforeStart);
		AddDialogHook("JOURNEY_SHOP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICO813_SUBQ07_START1", "F_NICOPOLIS_81_3_SQ_07", "What are you going to do with the research papers?", "I trust you can do that on your own."))
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

		await dialog.Msg("NICO813_SUBQ07_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

