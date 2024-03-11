//--- Melia Script -----------------------------------------------------------
// Lead to a Dead-end (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Mage Melchioras.
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

[QuestScript(70445)]
public class Quest70445Script : QuestScript
{
	protected override void Load()
	{
		SetId(70445);
		SetName("Lead to a Dead-end (1)");
		SetDescription("Talk to Mage Melchioras");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CASTLE65_3_MQ05"));

		AddDialogHook("CASTLE653_MQ_06", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE653_MQ_07_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE653_MQ_06_start", "CASTLE65_3_MQ06", "Don't worry, just get some rest", "I need to prepare"))
		{
			case 1:
				await dialog.Msg("CASTLE653_MQ_06_AG");
				// Func/SCR_CASTLE653_MQ_06_P;
				await dialog.Msg("FadeOutIN/1000");
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


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CASTLE65_3_MQ07");
	}
}

