//--- Melia Script -----------------------------------------------------------
// The Dimensional Crack (7)
//--- Description -----------------------------------------------------------
// Quest to Seal the dimensional crack.
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

[QuestScript(60042)]
public class Quest60042Script : QuestScript
{
	protected override void Load()
	{
		SetId(60042);
		SetName("The Dimensional Crack (7)");
		SetDescription("Seal the dimensional crack");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "VPRISON515_MQ_06_AFTER");

		AddPrerequisite(new LevelPrerequisite(163));
		AddPrerequisite(new CompletedPrerequisite("VPRISON515_MQ_06"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 109));
		AddReward(new ItemReward("Vis", 48900));

		AddDialogHook("VPRISON515_MQ_VAKARINE", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON515_MQ_VAKARINE", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("VPRISON515_MQ_06_03");
		dialog.UnHideNPC("VPRISON515_MQ_SIGITA");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You have survived a formidable experience!{nl}Speak with the Wings of Vaivora NPC to record your experience and collect your reward!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

