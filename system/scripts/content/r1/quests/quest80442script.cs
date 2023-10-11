//--- Melia Script -----------------------------------------------------------
// First Step Towards the Final Battle (1)
//--- Description -----------------------------------------------------------
// Quest to Call Neringa.
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

[QuestScript(80442)]
public class Quest80442Script : QuestScript
{
	protected override void Load()
	{
		SetId(80442);
		SetName("First Step Towards the Final Battle (1)");
		SetDescription("Call Neringa");

		AddPrerequisite(new LevelPrerequisite(421));
		AddPrerequisite(new CompletedPrerequisite("D_CASTLE_19_1_MQ_PRE"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));

		AddDialogHook("D_CASTLE_19_1_MQ_NERINGA", "BeforeStart", BeforeStart);
		AddDialogHook("D_CASTLE_19_1_MQ_NERINGA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("D_CASTLE_19_1_MQ_01_ST", "D_CASTLE_19_1_MQ_01", "I'm ready.", "I'm not ready yet."))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("D_CASTLE_19_1_MQ_01_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

