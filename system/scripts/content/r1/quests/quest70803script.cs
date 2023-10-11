//--- Melia Script -----------------------------------------------------------
// Poison will be strong enough
//--- Description -----------------------------------------------------------
// Quest to Track the mysterious hunter.
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

[QuestScript(70803)]
public class Quest70803Script : QuestScript
{
	protected override void Load()
	{
		SetId(70803);
		SetName("Poison will be strong enough");
		SetDescription("Track the mysterious hunter");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "WHITETREES23_1_SQ04_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(316));
		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_1_SQ01"), new CompletedPrerequisite("WHITETREES23_1_SQ03"));

		AddObjective("kill0", "Kill 12 Kugheri Sommi(s) or Kugheri Lyoni(s)", new KillObjective(12, 58547, 58548));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("WHITETREES231_SQ_04", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES231_SQ_05", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("WHITETREES231_SQ_04_succ1");
		await dialog.Msg("WHITETREES231_SQ_04_succ2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

