//--- Melia Script -----------------------------------------------------------
// Pull out the Metal Plate
//--- Description -----------------------------------------------------------
// Quest to Talk to Alruida.
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

[QuestScript(40740)]
public class Quest40740Script : QuestScript
{
	protected override void Load()
	{
		SetId(40740);
		SetName("Pull out the Metal Plate");
		SetDescription("Talk to Alruida");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "REMAINS37_3_SQ_080_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_3_SQ_070"));

		AddObjective("kill0", "Kill 1 Ground Vines", new KillObjective(1, MonsterId.Vine_01));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("REMAINS37_3_ALVYDA", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_3_ALVYDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS37_3_SQ_080_ST", "REMAINS37_3_SQ_080", "Tell him that you would bring it", "The reason that you could find the Metal Plate easily", "Decline"))
		{
			case 1:
				await dialog.Msg("REMAINS37_3_SQ_080_AC");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("REMAINS37_3_SQ_080_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("REMAINS37_3_SQ_080_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

