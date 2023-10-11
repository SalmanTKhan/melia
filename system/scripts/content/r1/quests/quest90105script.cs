//--- Melia Script -----------------------------------------------------------
// Plot Twist (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Lina.
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

[QuestScript(90105)]
public class Quest90105Script : QuestScript
{
	protected override void Load()
	{
		SetId(90105);
		SetName("Plot Twist (2)");
		SetDescription("Talk to Kupole Lina");

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_3_SQ_100"));

		AddDialogHook("MAPLE_25_3_LINA", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_3_LINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_3_SQ_110_ST", "MAPLE_25_3_SQ_110", "Are you fighting because of the leaves?", "I'm not sure"))
		{
			case 1:
				character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
				await dialog.Msg("MAPLE_25_3_SQ_110_AG1_1");
				await dialog.Msg("지금, 하나의 몸으로 두 큐폴이 말하고 있다고 말해준다");
				await dialog.Msg("MAPLE_25_3_SQ_110_AG");
				await dialog.Msg("MAPLE_25_3_SQ_110_AG2");
				await dialog.Msg("MAPLE_25_3_SQ_110_AG3");
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

		await dialog.Msg("MAPLE_25_3_SQ_110_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

