//--- Melia Script -----------------------------------------------------------
// Ensuring Safety (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Monk Chad.
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

[QuestScript(80217)]
public class Quest80217Script : QuestScript
{
	protected override void Load()
	{
		SetId(80217);
		SetName("Ensuring Safety (1)");
		SetDescription("Talk to the Monk Chad");

		AddPrerequisite(new LevelPrerequisite(176));
		AddPrerequisite(new CompletedPrerequisite("THORN39_1_SQ03"));

		AddObjective("kill0", "Kill 7 Infrogalas Mage(s)", new KillObjective(7, MonsterId.Infrogalas_Mage));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("THORN391_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("THORN391_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_1_SQ05_select01", "THORN39_1_SQ05", "I'll sort it out for you.", "I'm sure you can do this on your own."))
		{
			case 1:
				await dialog.Msg("THORN39_1_SQ05_agree01");
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

		await dialog.Msg("THORN39_1_SQ05_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

