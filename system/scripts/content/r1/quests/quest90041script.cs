//--- Melia Script -----------------------------------------------------------
// Fast Asleep
//--- Description -----------------------------------------------------------
// Quest to Talk to the Raucous Owl Sculpture.
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

[QuestScript(90041)]
public class Quest90041Script : QuestScript
{
	protected override void Load()
	{
		SetId(90041);
		SetName("Fast Asleep");
		SetDescription("Talk to the Raucous Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(245));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_1_SQ_9"));

		AddObjective("kill0", "Kill 16 Green Socket(s) or Green Socket Mage(s) or Brown Stoulet Archer(s) or Gray Stoulet(s)", new KillObjective(16, 57926, 57929, 57919, 57915));

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

		switch (await dialog.Select("KATYN_45_1_SQ_11_ST", "KATYN_45_1_SQ_11", "I can help.", "It will be okay"))
		{
			case 1:
				await dialog.Msg("KATYN_45_1_SQ_11_AG");
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

		await dialog.Msg("KATYN_45_1_SQ_11_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

