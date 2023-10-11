//--- Melia Script -----------------------------------------------------------
// Goddess Gabija
//--- Description -----------------------------------------------------------
// Quest to Use the Jewel of Prominence.
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

[QuestScript(8498)]
public class Quest8498Script : QuestScript
{
	protected override void Load()
	{
		SetId(8498);
		SetName("Goddess Gabija");
		SetDescription("Use the Jewel of Prominence");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FTOWER45_MQ_05_GABIA_END_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(126));
		AddPrerequisite(new CompletedPrerequisite("FTOWER45_SQ_PRO"));

		AddReward(new ExpReward(690282, 690282));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 106));
		AddReward(new ItemReward("stonetablet05", 1));
		AddReward(new ItemReward("Vis", 40950));

		AddDialogHook("FTOWER45_MQ_05_D", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER45_MQ_06_D", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("FTOWER45_MQ_06_succ");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You have survived a formidable experience!{nl}Speak with the Wings of Vaivora NPC to record your experience and collect your reward!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

