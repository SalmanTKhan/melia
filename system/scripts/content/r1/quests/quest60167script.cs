//--- Melia Script -----------------------------------------------------------
// For Safety
//--- Description -----------------------------------------------------------
// Quest to Talk to Airine.
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

[QuestScript(60167)]
public class Quest60167Script : QuestScript
{
	protected override void Load()
	{
		SetId(60167);
		SetName("For Safety");
		SetDescription("Talk to Airine");

		AddPrerequisite(new LevelPrerequisite(67));
		AddPrerequisite(new CompletedPrerequisite("ROKAS27_QB_11"));

		AddObjective("kill0", "Kill 12 Sauga(s) or Tucen(s) or Loftlem(s) or Ticen(s)", new KillObjective(12, 401001, 57046, 57041, 57045));

		AddReward(new ExpReward(24571, 24571));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Vis", 1273));

		AddDialogHook("ROKAS27_AIRINE2", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS27_AIRINE2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS27_RP_1_1", "ROKAS27_RP_1", "I will defeat it", "I'm busy"))
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

		await dialog.Msg("ROKAS27_RP_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

