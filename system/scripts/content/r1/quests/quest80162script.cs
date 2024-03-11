//--- Melia Script -----------------------------------------------------------
// Reducing Numbers
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

[QuestScript(80162)]
public class Quest80162Script : QuestScript
{
	protected override void Load()
	{
		SetId(80162);
		SetName("Reducing Numbers");
		SetDescription("Talk to Kupole Medena");

		AddPrerequisite(new LevelPrerequisite(301));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_4_MQ_BLACKMAN"));

		AddObjective("kill0", "Kill 7 Green Flamil(s) or Rondo(s)", new KillObjective(7, 58476, 47481));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 13846));

		AddDialogHook("LIMESTONECAVE_52_5_MEDENA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_5_MEDENA_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_5_MQ_1_start", "LIMESTONE_52_5_MQ_1", "Let's do it.", "We don't have time for it"))
		{
			case 1:
				// Func/LIMESTONECAVE_HIDE_FUNC_RUN;
				dialog.HideNPC("LIMESTONECAVE_52_5_MEDENA");
				// Func/LIMESTONE_52_5_MQ_RUNNPC;
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

		await dialog.Msg("LIMESTONE_52_5_MQ_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

