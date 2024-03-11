//--- Melia Script -----------------------------------------------------------
// Large-Scale Search Operation (6)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Pranas.
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

[QuestScript(60104)]
public class Quest60104Script : QuestScript
{
	protected override void Load()
	{
		SetId(60104);
		SetName("Large-Scale Search Operation (6)");
		SetDescription("Talk with Priest Pranas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAU11RE_MQ_05"));

		AddReward(new ExpReward(26860, 26860));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 169));

		AddDialogHook("SIAULIAI11RE_PRANAS", "BeforeStart", BeforeStart);
		AddDialogHook("C_ORSHA_PRANAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU11RE_MQ_06_01", "SIAU11RE_MQ_06", "I'll try to find them", "It's better to tend to the injuries first"))
		{
			case 1:
				// Func/SIAU11RE_MQ_04_AFTER_DIR_AI;
				await Task.Delay(4000);
				await dialog.Msg("SIAU11RE_MQ_06_01_01");
				await dialog.Msg("FadeOutIN/2500");
				// Func/SIAU11RE_MQ_04_AFTER_DIR_DEAD;
				dialog.HideNPC("SIAULIAI11RE_PRANAS");
				dialog.UnHideNPC("SIAU11RE_MQ_06_NPC");
				dialog.UnHideNPC("C_ORSHA_PRANAS");
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
}

