//--- Melia Script -----------------------------------------------------------
// Kupole in Danger (2)
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

[QuestScript(80114)]
public class Quest80114Script : QuestScript
{
	protected override void Load()
	{
		SetId(80114);
		SetName("Kupole in Danger (2)");
		SetDescription("Talk to Kupole Medena");

		AddPrerequisite(new LevelPrerequisite(287));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_1_MQ_1"));

		AddObjective("kill0", "Kill 9 Lakhorn(s) or Tala Wizard(s) or Green Flak(s) or Lakhof(s)", new KillObjective(9, 58437, 58433, 58475, 58439));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12054));

		AddDialogHook("LIMESTONECAVE_52_1_MEDENA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_1_MEDENA_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_1_MQ_2_start", "LIMESTONE_52_1_MQ_2", "I'll take care of the monsters.", "I don't think I'm the savior you're looking for."))
		{
			case 1:
				// Func/LIMESTONECAVE_HIDE_FUNC_RUN;
				dialog.HideNPC("LIMESTONECAVE_52_1_MEDENA");
				// Func/LIMESTONE_52_1_MQ_2_RUNNPC;
				dialog.UnHideNPC("LIMSTONE_52_1_CART");
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

		await dialog.Msg("LIMESTONE_52_1_MQ_2_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

