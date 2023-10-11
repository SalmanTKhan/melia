//--- Melia Script -----------------------------------------------------------
// Trap after trap(1)
//--- Description -----------------------------------------------------------
// Quest to Deal with the trapped monsters.
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

[QuestScript(70801)]
public class Quest70801Script : QuestScript
{
	protected override void Load()
	{
		SetId(70801);
		SetName("Trap after trap(1)");
		SetDescription("Deal with the trapped monsters");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "WHITETREES23_1_SQ02_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(316));
		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_1_SQ01"));

		AddObjective("kill0", "Kill 5 Kugheri Tot(s)", new KillObjective(5, MonsterId.Kucarry_Tot));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("WHITETREES231_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES231_SQ_02", "BeforeEnd", BeforeEnd);
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


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("WHITETREES23_1_SQ03");
	}
}

