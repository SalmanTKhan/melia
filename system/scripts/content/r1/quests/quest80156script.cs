//--- Melia Script -----------------------------------------------------------
// With the Power of the Goddess (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Medena.
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

[QuestScript(80156)]
public class Quest80156Script : QuestScript
{
	protected override void Load()
	{
		SetId(80156);
		SetName("With the Power of the Goddess (1)");
		SetDescription("Talk to Kupole Medena");

		AddPrerequisite(new LevelPrerequisite(298));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_4_MQ_7"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));

		AddDialogHook("LIMESTONECAVE_52_4_MEDENA_2", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_4_SAULE_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_4_MQ_8_start", "LIMESTONE_52_4_MQ_8", "We should leave right away.", "Let's rest first; then we can leave."))
		{
			case 1:
				// Func/LIMESTONECAVE_HIDE_FUNC_RUN;
				dialog.HideNPC("LIMESTONECAVE_52_4_MEDENA_2");
				dialog.UnHideNPC("LIMESTONECAVE_52_4_MEDENA_AI");
				await Task.Delay(1000);
				await dialog.Msg("LIMESTONE_52_4_MQ_8_ST_AFTER");
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

		character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
		await dialog.Msg("LIMESTONE_52_4_MQ_8_SUC01");
		await dialog.Msg("성구를 보여주며 테브린 종유동의 일을 말한다");
		await dialog.Msg("LIMESTONE_52_4_MQ_8_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

