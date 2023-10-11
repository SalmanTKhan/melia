//--- Melia Script -----------------------------------------------------------
// Purify the Holy Pond
//--- Description -----------------------------------------------------------
// Quest to Purify the Holy Pond.
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

[QuestScript(18110)]
public class Quest18110Script : QuestScript
{
	protected override void Load()
	{
		SetId(18110);
		SetName("Purify the Holy Pond");
		SetDescription("Purify the Holy Pond");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "HUEVILLAGE_58_1_MQ02_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(36));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_1_MQ01"));

		AddReward(new ExpReward(151956, 151956));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 62));
		AddReward(new ItemReward("Drug_SP1_Q", 30));
		AddReward(new ItemReward("Vis", 504));

		AddDialogHook("HUEVILLAGE_58_1_MQ02_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_1_MQ01_NPC", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("HUEVILLAGE_58_1_MQ02_succ");
		dialog.UnHideNPC("HUEVILLAGE_58_1_MQ03_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("HUEVILLAGE_58_1_MQ03");
	}
}

