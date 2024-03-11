//--- Melia Script -----------------------------------------------------------
// Defeat the stragglers
//--- Description -----------------------------------------------------------
// Quest to Talk with Loremaster Emmanuelis.
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

[QuestScript(90220)]
public class Quest90220Script : QuestScript
{
	protected override void Load()
	{
		SetId(90220);
		SetName("Defeat the stragglers");
		SetDescription("Talk with Loremaster Emmanuelis");

		AddPrerequisite(new LevelPrerequisite(335));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_3_SQ_70"));

		AddObjective("kill0", "Kill 20 Varle Anchor(s) or Varle Skipper(s) or Varle Henchmen(s) or Varle Helmsman(s) or Nimrah Frieker(s)", new KillObjective(20, 58830, 58828, 58829, 58831, 58880));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));

		AddDialogHook("CORAL_44_3_MAN1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_3_MAN1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_3_SQ_100_ST", "CORAL_44_3_SQ_100", "I'll eradicate the stragglers", "It has to be easier now"))
		{
			case 1:
				await dialog.Msg("CORAL_44_3_SQ_100_AG");
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

		await dialog.Msg("CORAL_44_3_SQ_100_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

