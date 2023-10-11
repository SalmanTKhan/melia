//--- Melia Script -----------------------------------------------------------
// How to beat stronger foes(3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Soul.
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

[QuestScript(30151)]
public class Quest30151Script : QuestScript
{
	protected override void Load()
	{
		SetId(30151);
		SetName("How to beat stronger foes(3)");
		SetDescription("Talk to Zanas' Soul");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PRISON_78_MQ_7_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(259));
		AddPrerequisite(new CompletedPrerequisite("PRISON_78_MQ_6"));

		AddObjective("kill0", "Kill 1 Mandara", new KillObjective(1, MonsterId.Boss_Mandara_Q1));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 17));
		AddReward(new ItemReward("Vis", 10360));

		AddDialogHook("PRISON_78_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_78_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_78_MQ_7_select", "PRISON_78_MQ_7", "Say that you will defeat Mandara", "Say that you need some more time"))
		{
			case 1:
				await dialog.Msg("PRISON_78_MQ_7_agree");
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

		await dialog.Msg("PRISON_78_MQ_7_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

