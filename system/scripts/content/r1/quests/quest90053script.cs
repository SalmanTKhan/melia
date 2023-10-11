//--- Melia Script -----------------------------------------------------------
// For Safety (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Aisol.
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

[QuestScript(90053)]
public class Quest90053Script : QuestScript
{
	protected override void Load()
	{
		SetId(90053);
		SetName("For Safety (1)");
		SetDescription("Talk to Dievdirbys Aisol");

		AddPrerequisite(new LevelPrerequisite(249));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_1_SQ_8"));

		AddObjective("kill0", "Kill 16 Blue Ridimed(s) or Black Old Kepa(s) or Red Puragi(s)", new KillObjective(16, 400542, 400483, 400304));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 9213));

		AddDialogHook("KATYN_45_2_ESOL", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_2_ESOL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_2_SQ_12_ST", "KATYN_45_2_SQ_12", "Sure, I'll help", "My hands are tied at the moment."))
		{
			case 1:
				await dialog.Msg("KATYN_45_2_SQ_12_AG");
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

		await dialog.Msg("KATYN_45_2_SQ_12_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

