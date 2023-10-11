//--- Melia Script -----------------------------------------------------------
// The Incident That Happened Here (2)
//--- Description -----------------------------------------------------------
// Quest to Chase after the sound of the scream.
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

[QuestScript(80055)]
public class Quest80055Script : QuestScript
{
	protected override void Load()
	{
		SetId(80055);
		SetName("The Incident That Happened Here (2)");
		SetDescription("Chase after the sound of the scream");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "TABLELAND_11_1_SQ_04_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(208));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_11_1_SQ_03"));

		AddObjective("kill0", "Kill 20 Red Saltisdaughter(s) or Green Saltisdaughter Archer(s) or White Groll(s)", new KillObjective(20, 57936, 57937, 57324));

		AddReward(new ExpReward(1082046, 1082046));
		AddReward(new ItemReward("expCard11", 4));
		AddReward(new ItemReward("Vis", 7280));

		AddDialogHook("TABLELAND_11_1_SQ_04_TRIG", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND_11_1_LEMIJA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("TABLELAND_11_1_SQ_04_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

