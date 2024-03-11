//--- Melia Script -----------------------------------------------------------
// The Road Back(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Spirit at the Reintegration Workshop.
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

[QuestScript(30174)]
public class Quest30174Script : QuestScript
{
	protected override void Load()
	{
		SetId(30174);
		SetName("The Road Back(1)");
		SetDescription("Talk to Zanas' Spirit at the Reintegration Workshop");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PRISON_81_MQ_1_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(269));
		AddPrerequisite(new CompletedPrerequisite("PRISON_80_MQ_10"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));

		AddDialogHook("PRISON_81_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_81_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_81_MQ_1_select", "PRISON_81_MQ_1"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("PRISON_81_MQ_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

