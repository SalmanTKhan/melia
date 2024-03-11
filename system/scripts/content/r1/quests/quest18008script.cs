//--- Melia Script -----------------------------------------------------------
// Goddess Saule
//--- Description -----------------------------------------------------------
// Quest to Remove restraining sphere that is trapping Goddess Saule.
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

[QuestScript(18008)]
public class Quest18008Script : QuestScript
{
	protected override void Load()
	{
		SetId(18008);
		SetName("Goddess Saule");
		SetDescription("Remove restraining sphere that is trapping Goddess Saule");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "HUEVILLAGE_58_4_MQ08_TRACK", 3000);

		AddPrerequisite(new LevelPrerequisite(55));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_4_MQ07"));

		AddReward(new ExpReward(67536, 67536));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));
		AddReward(new ItemReward("Vis", 990));

		AddDialogHook("HUEVILLAGE_58_4_SAULE_BEFORE", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_4_SAULE_AFTER", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("HUEVILLAGE_58_4_MQ08_succ");
		dialog.UnHideNPC("JOB_DIEVDIRBYS2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("HUEVILLAGE_58_4_MQ09");
	}
}

