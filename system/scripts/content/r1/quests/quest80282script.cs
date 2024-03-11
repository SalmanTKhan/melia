//--- Melia Script -----------------------------------------------------------
// Housekeeping
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Adjutant Lehon.
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

[QuestScript(80282)]
public class Quest80282Script : QuestScript
{
	protected override void Load()
	{
		SetId(80282);
		SetName("Housekeeping");
		SetDescription("Talk to Resistance Adjutant Lehon");

		AddPrerequisite(new LevelPrerequisite(366));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_18"));

		AddObjective("kill0", "Kill 16 Spinacho(s) or Rubeta(s) or Little Rubeta(s) or Lilly Maid(s) or Noli Maid(s)", new KillObjective(16, 59074, 59075, 59076, 59073, 59077));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 19032));

		AddDialogHook("F_3CMLAKE_86_MQ_15_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_86_MQ_15_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_86_SQ_05_ST", "F_3CMLAKE_86_SQ_05", "I'll take care of them.", "There's too many of them."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_86_SQ_05_AFST");
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

		await dialog.Msg("F_3CMLAKE_86_SQ_05_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

