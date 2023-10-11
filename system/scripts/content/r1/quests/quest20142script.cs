//--- Melia Script -----------------------------------------------------------
// Strange Stone
//--- Description -----------------------------------------------------------
// Quest to Talk to Liaison Officer Nian.
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

[QuestScript(20142)]
public class Quest20142Script : QuestScript
{
	protected override void Load()
	{
		SetId(20142);
		SetName("Strange Stone");
		SetDescription("Talk to Liaison Officer Nian");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS28_MQ1_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(69));

		AddObjective("kill0", "Kill 18 Lauzinute(s) or Hogma Archer(s)", new KillObjective(18, 47328, 41434));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1311));

		AddDialogHook("ROKAS28_MQ1_1", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS28_MQ1_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS28_MQ1_01", "ROKAS28_MQ1", "Touch the stone to look closely", "Just go"))
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

		await dialog.Msg("ROKAS28_MQ1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

