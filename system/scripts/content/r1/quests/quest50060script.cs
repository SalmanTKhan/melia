//--- Melia Script -----------------------------------------------------------
// Reclaim the Camp (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Royal Army Guard Delus.
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

[QuestScript(50060)]
public class Quest50060Script : QuestScript
{
	protected override void Load()
	{
		SetId(50060);
		SetName("Reclaim the Camp (5)");
		SetDescription("Talk to Royal Army Guard Delus");
		SetTrack(QuestStatus.Progress, QuestStatus.Complete, "UNDERFORTRESS_66_MQ060_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(204));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_66_MQ050"));

		AddObjective("kill0", "Kill 1 Specter Monarch", new KillObjective(1, MonsterId.Boss_Spector_M_Q2));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 49980));

		AddDialogHook("UNDER66_DELLOOS03", "BeforeStart", BeforeStart);
		AddDialogHook("UNDER66_MQ07_GHOST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDERFORTRESS_66_MQ060_startnpc01", "UNDERFORTRESS_66_MQ060", "Alright", "Think about it one more time"))
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

		await dialog.Msg("UNDERFORTRESS_66_MQ060_succ01");
		// Func/UNDER66_MQ6_ITEM01_REMOVE;
		dialog.UnHideNPC("UNDER66_TO_UNDER65_SECRET_ROOM");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

