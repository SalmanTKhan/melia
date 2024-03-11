//--- Melia Script -----------------------------------------------------------
// The Legend of the Goddess' Seal (1)
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

[QuestScript(80115)]
public class Quest80115Script : QuestScript
{
	protected override void Load()
	{
		SetId(80115);
		SetName("The Legend of the Goddess' Seal (1)");
		SetDescription("Talk to Kupole Medena");

		AddPrerequisite(new LevelPrerequisite(287));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_1_MQ_2"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("LIMESTONECAVE_52_1_MEDENA_AI", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_1_MEDENA_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_1_MQ_3_start", "LIMESTONE_52_1_MQ_3", "Let's go.", "Please wait"))
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

		await dialog.Msg("LIMESTONE_52_1_MQ_3_succ");
		// Func/LIMESTONECAVE_HIDE_FUNC_RUN;
		dialog.HideNPC("LIMESTONECAVE_52_1_MEDENA_AI");
		dialog.UnHideNPC("LIMESTONECAVE_52_1_MEDENA_2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

