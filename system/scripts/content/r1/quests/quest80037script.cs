//--- Melia Script -----------------------------------------------------------
// Recording the Behavior
//--- Description -----------------------------------------------------------
// Quest to Speak with Druid Benes.
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

[QuestScript(80037)]
public class Quest80037Script : QuestScript
{
	protected override void Load()
	{
		SetId(80037);
		SetName("Recording the Behavior");
		SetDescription("Speak with Druid Benes");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 1920));

		AddDialogHook("ORCHARD342_BENES", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD342_BENES", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_342_SQ_01_start", "ORCHARD_342_SQ_01", "I'll help you", "I'm afraid I can't help you now"))
		{
			case 1:
				await dialog.Msg("ORCHARD_342_SQ_01_AC");
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


		return HookResult.Break;
	}
}

