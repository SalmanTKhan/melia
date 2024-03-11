//--- Melia Script -----------------------------------------------------------
// Passing Words (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with Kupole Vita.
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

[QuestScript(30019)]
public class Quest30019Script : QuestScript
{
	protected override void Load()
	{
		SetId(30019);
		SetName("Passing Words (3)");
		SetDescription("Talk with Kupole Vita");

		AddPrerequisite(new LevelPrerequisite(194));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_38_1_SQ_02"));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 6014));

		AddDialogHook("CATACOMB_38_1_NPC_02", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_38_1_OBJ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_38_1_SQ_03_select", "CATACOMB_38_1_SQ_03", "Let's go to destroy the pot", "About the elimination of the spirit", "Tell him that you will quit since it looks dangerous"))
		{
			case 1:
				await dialog.Msg("CATACOMB_38_1_SQ_03_agree");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("CATACOMB_38_1_SQ_03_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_38_1_SQ_04");
	}
}

