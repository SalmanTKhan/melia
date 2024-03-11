//--- Melia Script -----------------------------------------------------------
// Unsettled Totems (2)
//--- Description -----------------------------------------------------------
// Quest to Defeat Simorph.
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

[QuestScript(17240)]
public class Quest17240Script : QuestScript
{
	protected override void Load()
	{
		SetId(17240);
		SetName("Unsettled Totems (2)");
		SetDescription("Defeat Simorph");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "GELE572_MQ_05_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(29));
		AddPrerequisite(new CompletedPrerequisite("GELE572_MQ_04"));

		AddReward(new ExpReward(26860, 26860));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 406));

		AddDialogHook("GELE572_MQ_05", "BeforeStart", BeforeStart);
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

		await dialog.Msg("GELE572_MQ_05_COMP_01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

