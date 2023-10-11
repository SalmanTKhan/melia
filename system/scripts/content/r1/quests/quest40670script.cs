//--- Melia Script -----------------------------------------------------------
// The Smell of Oil
//--- Description -----------------------------------------------------------
// Quest to Meet Justas.
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

[QuestScript(40670)]
public class Quest40670Script : QuestScript
{
	protected override void Load()
	{
		SetId(40670);
		SetName("The Smell of Oil");
		SetDescription("Meet Justas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "REMAINS37_3_SQ_010_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(176));

		AddObjective("kill0", "Kill 15 Hallowventer Shaman(s) or Hallowventer Magician(s)", new KillObjective(15, 57595, 57594));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("REMAINS37_3_JUSTAS", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_3_JUSTAS_AFTER", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("REMAINS37_3_SQ_010_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

