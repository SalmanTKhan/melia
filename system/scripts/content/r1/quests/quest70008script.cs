//--- Melia Script -----------------------------------------------------------
// Unreliable Folk
//--- Description -----------------------------------------------------------
// Quest to Talk to Farmer Miren.
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

[QuestScript(70008)]
public class Quest70008Script : QuestScript
{
	protected override void Load()
	{
		SetId(70008);
		SetName("Unreliable Folk");
		SetDescription("Talk to Farmer Miren");

		AddPrerequisite(new LevelPrerequisite(149));

		AddObjective("kill0", "Kill 12 Orange Lizardman(s)", new KillObjective(12, MonsterId.Lizardman_Orange));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3874));

		AddDialogHook("FARM491_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("FARM491_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_1_SQ_03_1", "FARM49_1_SQ03", "I'll help", "About the mysterious girl", "I'm busy so I'll pass"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM49_1_SQ_03_2");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM49_1_SQ_03_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

