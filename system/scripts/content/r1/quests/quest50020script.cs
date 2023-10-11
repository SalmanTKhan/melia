//--- Melia Script -----------------------------------------------------------
// Louise's Farmland (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Louise.
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

[QuestScript(50020)]
public class Quest50020Script : QuestScript
{
	protected override void Load()
	{
		SetId(50020);
		SetName("Louise's Farmland (1)");
		SetDescription("Talk to Louise");

		AddPrerequisite(new LevelPrerequisite(70));

		AddObjective("kill0", "Kill 10 Black Ridimed(s)", new KillObjective(10, MonsterId.Ridimed_Purple));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1330));

		AddDialogHook("SIAULIAI_50_1_SQ_MAN01", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_50_1_SQ_MAN01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_50_1_SQ_130_select01", "SIAULIAI_50_1_SQ_130", "I will defeat the monsters on behalf of him", "About the settlement land of Gytis", "Ignore"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("SIAULIAI_50_1_SQ_140_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("SIAULIAI_50_1_SQ_130_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

