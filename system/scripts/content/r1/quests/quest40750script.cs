//--- Melia Script -----------------------------------------------------------
// Find the Metal Plate (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Alruida.
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

[QuestScript(40750)]
public class Quest40750Script : QuestScript
{
	protected override void Load()
	{
		SetId(40750);
		SetName("Find the Metal Plate (1)");
		SetDescription("Talk to Alruida");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("REMAINS37_3_ALVYDA", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS37_3_SQ_090_ST", "REMAINS37_3_SQ_090", "I will go", "Decline"))
		{
			case 1:
				await dialog.Msg("REMAINS37_3_SQ_090_AC");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

