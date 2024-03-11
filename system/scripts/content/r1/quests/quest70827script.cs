//--- Melia Script -----------------------------------------------------------
// Convincing Lord Joquvas(2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Roberta.
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

[QuestScript(70827)]
public class Quest70827Script : QuestScript
{
	protected override void Load()
	{
		SetId(70827);
		SetName("Convincing Lord Joquvas(2)");
		SetDescription("Talk to Roberta");

		AddPrerequisite(new LevelPrerequisite(319));
		AddPrerequisite(new CompletedPrerequisite("MAPLE23_2_SQ07"));

		AddObjective("kill0", "Kill 15 Red Colimen(s)", new KillObjective(15, MonsterId.Colimen_Red));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14674));

		AddDialogHook("MAPLE232_SQ_07_2", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE232_SQ_07_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE232_SQ_08_start", "MAPLE23_2_SQ08", "Say that you will deal with the monsters", "Refuse to do so until he listens to you"))
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

		await dialog.Msg("MAPLE232_SQ_08_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

