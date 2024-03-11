//--- Melia Script -----------------------------------------------------------
// Reclaim the Camp (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Royal Army Guard Delus.
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

[QuestScript(50058)]
public class Quest50058Script : QuestScript
{
	protected override void Load()
	{
		SetId(50058);
		SetName("Reclaim the Camp (3)");
		SetDescription("Talk to Royal Army Guard Delus");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "UNDERFORTRESS_66_MQ040_TRACK", "UNDER_66_MQ040_prog01");

		AddPrerequisite(new LevelPrerequisite(204));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_66_MQ030"));

		AddObjective("kill0", "Kill 9 Blue Ticen Magician(s) or Blue Ticen(s)", new KillObjective(9, 57960, 57956));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7140));

		AddDialogHook("UNDER66_DELLOOS01", "BeforeStart", BeforeStart);
		AddDialogHook("UNDER66_DELLOOS03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDERFORTRESS_66_MQ040_startnpc01", "UNDERFORTRESS_66_MQ040", "I'm ready", "I'm not yet ready"))
		{
			case 1:
				// Func/UNDER66_MQ040_TRACK;
				// Func/SCR_UNDER66_MQ4_GUADIAN_UNHIDE;
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

		await dialog.Msg("UNDERFORTRESS_66_MQ040_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

