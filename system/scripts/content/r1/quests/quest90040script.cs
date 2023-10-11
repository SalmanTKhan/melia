//--- Melia Script -----------------------------------------------------------
// Sweet Dreams (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Raucous Owl Sculpture.
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

[QuestScript(90040)]
public class Quest90040Script : QuestScript
{
	protected override void Load()
	{
		SetId(90040);
		SetName("Sweet Dreams (2)");
		SetDescription("Talk to the Raucous Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(245));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_1_SQ_9"));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 9065));

		AddDialogHook("KATYN_45_1_OWL3", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_1_OWL3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_1_SQ_10_ST", "KATYN_45_1_SQ_10", "I can do that.", "I can only help so much"))
		{
			case 1:
				await dialog.Msg("KATYN_45_1_SQ_10_AG");
				// Func/SCR_KATYN_45_1_SQ_10_START;
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

		dialog.HideNPC("KATYN_45_1_SQ_10_STONE1");
		dialog.HideNPC("KATYN_45_1_SQ_10_STONE2");
		await dialog.Msg("KATYN_45_1_SQ_10_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

