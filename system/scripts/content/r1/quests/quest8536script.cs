//--- Melia Script -----------------------------------------------------------
// Trapped Gesti
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Algis.
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

[QuestScript(8536)]
public class Quest8536Script : QuestScript
{
	protected override void Load()
	{
		SetId(8536);
		SetName("Trapped Gesti");
		SetDescription("Talk to Follower Algis");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CHAPLE577_MQ_09_TRACK", "m_boss_scenario");

		AddPrerequisite(new LevelPrerequisite(48));
		AddPrerequisite(new CompletedPrerequisite("CHAPLE577_MQ_04"));

		AddReward(new ExpReward(219492, 219492));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 21));
		AddReward(new ItemReward("KEY_OF_LEGEND_01", 1));
		AddReward(new ItemReward("Vis", 5760));

		AddDialogHook("CHAPLE577_ARUNE_02", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPLE577_ARUNE_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE577_MQ_09_01", "CHAPLE577_MQ_09", "I trust you", "About the Divine Sphere", "I'm not yet ready"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("CHAPLE577_MQ_09_01_add");
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

