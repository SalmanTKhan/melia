//--- Melia Script -----------------------------------------------------------
// First Step Towards the Final Battle (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa's Illusion.
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

[QuestScript(80443)]
public class Quest80443Script : QuestScript
{
	protected override void Load()
	{
		SetId(80443);
		SetName("First Step Towards the Final Battle (2)");
		SetDescription("Talk to Neringa's Illusion");

		AddPrerequisite(new LevelPrerequisite(421));
		AddPrerequisite(new CompletedPrerequisite("D_CASTLE_19_1_MQ_01"));

		AddObjective("kill0", "Kill 20 Vilktys(s) or Trampauld(s) or Tarnite(s) or Sodinincuz(s) or Viskal(s)", new KillObjective(20, 59351, 59352, 59363, 59362, 59350));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));
		AddReward(new ItemReward("Vis", 24418));

		AddDialogHook("D_CASTLE_19_1_MQ_NERINGA", "BeforeStart", BeforeStart);
		AddDialogHook("D_CASTLE_19_1_MQ_NERINGA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("D_CASTLE_19_1_MQ_02_ST", "D_CASTLE_19_1_MQ_02", "Alright", "I don't think I can handle it."))
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

		await dialog.Msg("D_CASTLE_19_1_MQ_02_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

