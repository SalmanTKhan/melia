//--- Melia Script -----------------------------------------------------------
// His Name is Zanas
//--- Description -----------------------------------------------------------
// Quest to Call Zanas' Spirit from the Demon's Barrier.
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

[QuestScript(30193)]
public class Quest30193Script : QuestScript
{
	protected override void Load()
	{
		SetId(30193);
		SetName("His Name is Zanas");
		SetDescription("Call Zanas' Spirit from the Demon's Barrier");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PRISON_82_MQ_10_TRACK", "m_boss_scenario2");

		AddPrerequisite(new LevelPrerequisite(272));
		AddPrerequisite(new CompletedPrerequisite("PRISON_82_MQ_9"));
		AddPrerequisite(new ItemPrerequisite("PRISON_78_MQ_3_ITEM", -100));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 133824));

		AddDialogHook("PRISON_82_OBJ_2", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_82_OBJ_8", "BeforeEnd", BeforeEnd);
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


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("PRISON_82_MQ_11");
	}
}

