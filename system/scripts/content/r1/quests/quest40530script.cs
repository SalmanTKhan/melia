//--- Melia Script -----------------------------------------------------------
// Dead of the Dead (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Adrijus.
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

[QuestScript(40530)]
public class Quest40530Script : QuestScript
{
	protected override void Load()
	{
		SetId(40530);
		SetName("Dead of the Dead (1)");
		SetDescription("Talk to Adrijus");

		AddPrerequisite(new LevelPrerequisite(168));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_1_SQ_041"));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5040));

		AddDialogHook("REMAINS37_1_ADRIJUS", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS37_1_SQ_050_ST", "REMAINS37_1_SQ_050", "Ask him to get Craute Grass juice.", "About the meaningful forecast", "Tell him that the remaining forecasts would be insignificant"))
		{
			case 1:
				await dialog.Msg("REMAINS37_1_SQ_050_AC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("REMAINS37_1_SQ_050_ADD");
				break;
		}

		return HookResult.Break;
	}
}

