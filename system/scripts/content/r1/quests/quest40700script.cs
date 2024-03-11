//--- Melia Script -----------------------------------------------------------
// Location of the Metal Plate (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Justas.
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

[QuestScript(40700)]
public class Quest40700Script : QuestScript
{
	protected override void Load()
	{
		SetId(40700);
		SetName("Location of the Metal Plate (1)");
		SetDescription("Talk to Justas");

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_3_SQ_020"));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("REMAINS37_3_JUSTAS_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_3_JUSTAS_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS37_3_SQ_040_ST", "REMAINS37_3_SQ_040", "I'll bring it ", "Decline"))
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

		await dialog.Msg("REMAINS37_3_SQ_040_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

