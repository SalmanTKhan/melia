//--- Melia Script -----------------------------------------------------------
// Purifying Doll (2)
//--- Description -----------------------------------------------------------
// Quest to Defeat Wild Carnivore.
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

[QuestScript(17260)]
public class Quest17260Script : QuestScript
{
	protected override void Load()
	{
		SetId(17260);
		SetName("Purifying Doll (2)");
		SetDescription("Defeat Wild Carnivore");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "GELE572_MQ_07_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(29));
		AddPrerequisite(new CompletedPrerequisite("GELE572_MQ_06"));

		AddReward(new ExpReward(26860, 26860));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 406));

		AddDialogHook("GELE572_MQ_07", "BeforeStart", BeforeStart);
		AddDialogHook("GELE572_NPC_MORI", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("GELE572_MQ_07_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

