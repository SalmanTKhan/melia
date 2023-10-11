//--- Melia Script -----------------------------------------------------------
// Lethargic Refugees
//--- Description -----------------------------------------------------------
// Quest to Talk to Mayor Frege.
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

[QuestScript(90020)]
public class Quest90020Script : QuestScript
{
	protected override void Load()
	{
		SetId(90020);
		SetName("Lethargic Refugees");
		SetDescription("Talk to Mayor Frege");

		AddPrerequisite(new LevelPrerequisite(232));

		AddDialogHook("CORAL_32_1_PEOPLE1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_1_SQ_1_ST", "CORAL_32_1_SQ_1", "I'm listening", "I'm not interested"))
		{
			case 1:
				await dialog.Msg("CORAL_32_1_SQ_1_AG");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

