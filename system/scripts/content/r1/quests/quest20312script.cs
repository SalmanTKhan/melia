//--- Melia Script -----------------------------------------------------------
// Critical Situation
//--- Description -----------------------------------------------------------
// Quest to Talk to Bishop Aurelius at Uola Chapel.
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

[QuestScript(20312)]
public class Quest20312Script : QuestScript
{
	protected override void Load()
	{
		SetId(20312);
		SetName("Critical Situation");
		SetDescription("Talk to Bishop Aurelius at Uola Chapel");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CHATHEDRAL54_MQ03_PART2_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(141));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL54_MQ01_PART1"));

		AddObjective("kill0", "Kill 7 Blue Stoulet(s)", new KillObjective(7, MonsterId.Stoulet_Blue));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("CATHEDRAL54_MQ02_PART2_ITEM", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));
		AddReward(new ItemReward("Vis", 3666));

		AddDialogHook("CHATHEDRAL54_BISHOP_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("CATHEDRAL54MQ02_OBJECT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL54_MQ03_PART2_select", "CHATHEDRAL54_MQ03_PART2", "I will retrieve the Holy Symbol of Spiritual Power", "Decline"))
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

		ZoneServer.Instance.World.FindNPC("CATHEDRAL54MQ02_OBJECT")?.PlayEffectLocal(character.Connection, "F_pc_making_finish_white", 1f, "BOT");
		dialog.HideNPC("CATHEDRAL54MQ02_OBJECT");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

