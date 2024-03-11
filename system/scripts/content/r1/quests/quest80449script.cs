//--- Melia Script -----------------------------------------------------------
// Approval (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon King Baiga.
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

[QuestScript(80449)]
public class Quest80449Script : QuestScript
{
	protected override void Load()
	{
		SetId(80449);
		SetName("Approval (1)");
		SetDescription("Talk to Demon King Baiga");

		AddPrerequisite(new LevelPrerequisite(426));
		AddPrerequisite(new CompletedPrerequisite("D_CASTLE_19_1_MQ_07"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));

		AddDialogHook("F_CASTLE_97_MQ_01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_CASTLE_97_MQ_01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_CASTLE_97_MQ_01_ST", "F_CASTLE_97_MQ_01", "Don't underestimate me.", "Leave with your tail between your legs."))
		{
			case 1:
				await dialog.Msg("F_CASTLE_97_MQ_01_AFST");
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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

		await dialog.Msg("F_CASTLE_97_MQ_01_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

