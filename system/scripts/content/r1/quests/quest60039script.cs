//--- Melia Script -----------------------------------------------------------
// A Dead End
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Sigita.
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

[QuestScript(60039)]
public class Quest60039Script : QuestScript
{
	protected override void Load()
	{
		SetId(60039);
		SetName("A Dead End");
		SetDescription("Talk to Kupole Sigita");

		AddPrerequisite(new LevelPrerequisite(163));
		AddPrerequisite(new CompletedPrerequisite("VPRISON515_MQ_06"));

		AddObjective("kill0", "Kill 8 Hohen Gulak(s) or Green Griba(s) or Hohen Mage(s)", new KillObjective(8, 57720, 400442, 57718));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 4890));

		AddDialogHook("VPRISON515_MQ_SIGITA", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON515_MQ_SIGITA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON515_SQ_01_01", "VPRISON515_SQ_01", "I'll take care of it", "Everything will be alright"))
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

		await dialog.Msg("VPRISON515_SQ_01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

