//--- Melia Script -----------------------------------------------------------
// The True Nature of the Trace (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Kupole Leda.
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

[QuestScript(90148)]
public class Quest90148Script : QuestScript
{
	protected override void Load()
	{
		SetId(90148);
		SetName("The True Nature of the Trace (1)");
		SetDescription("Talk with Kupole Leda");

		AddPrerequisite(new LevelPrerequisite(295));
		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_6_SQ_80"));

		AddDialogHook("DCAPITAL_20_6_REDA", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_DCAPITAL_20_6_SQ_90_ST", "F_DCAPITAL_20_6_SQ_90", "What is the correlationship between the altar and the trace?", "I'm not sure"))
		{
			case 1:
				await dialog.Msg("F_DCAPITAL_20_6_SQ_90_AG");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

