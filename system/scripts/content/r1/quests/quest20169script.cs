//--- Melia Script -----------------------------------------------------------
// Treasure Hunting (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Rolandas Jonas.
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

[QuestScript(20169)]
public class Quest20169Script : QuestScript
{
	protected override void Load()
	{
		SetId(20169);
		SetName("Treasure Hunting (1)");
		SetDescription("Talk to Rolandas Jonas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS27_MQ_1_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(67));
		AddPrerequisite(new CompletedPrerequisite("ROKAS26_MQ2"));

		AddObjective("kill0", "Kill 12 Sauga(s)", new KillObjective(12, MonsterId.Sauga_S));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Vis", 1273));

		AddDialogHook("ROKAS27_REXITHER_1", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS27_REXITHER_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS27_MQ_1_select01", "ROKAS27_MQ_1", "I'll find the map", "I'll quit here"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("ROKAS27_MQ_1_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

