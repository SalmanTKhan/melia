//--- Melia Script -----------------------------------------------------------
// Revelator of Moroth (13)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kaoneela Henrjusi.
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

[QuestScript(63117)]
public class Quest63117Script : QuestScript
{
	protected override void Load()
	{
		SetId(63117);
		SetName("Revelator of Moroth (13)");
		SetDescription("Talk to Kaoneela Henrjusi");

		AddPrerequisite(new LevelPrerequisite(440));
		AddPrerequisite(new CompletedPrerequisite("EP14_3LINE_TUTO_MQ_12"));

		AddReward(new ItemReward("TP_jexpCard_UpRank4", 1));

		AddDialogHook("EP14_KAONEELA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_HEOSHAA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_3LINE_TUTO_MQ_13_1", "EP14_3LINE_TUTO_MQ_13", "Alright", "I'll wait a little bit"))
		{
			case 1:
				// Func/SCR_EP14_3LINE_TUTO_MQ_13_scroll_RUN;
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

		await dialog.Msg("EP14_3LINE_TUTO_MQ_13_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_3LINE_TUTO_MQ_14");
	}
}

