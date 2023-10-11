//--- Melia Script -----------------------------------------------------------
// Re-Confirm
//--- Description -----------------------------------------------------------
// Quest to Speak with Loremaster Ugnius.
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

[QuestScript(90203)]
public class Quest90203Script : QuestScript
{
	protected override void Load()
	{
		SetId(90203);
		SetName("Re-Confirm");
		SetDescription("Speak with Loremaster Ugnius");

		AddPrerequisite(new LevelPrerequisite(331));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_2_SQ_30"));

		AddObjective("kill0", "Kill 16 Nimrah Lancer(s) or Nimrah Soldier(s) or Varle Gunner(s) or Varle Hench(s) or Nimrah Duke(s)", new KillObjective(16, 58824, 58825, 58826, 58827, 58879));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));

		AddDialogHook("CORAL_44_2_OLDMAN", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_2_OLDMAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_2_SQ_40_ST", "CORAL_44_2_SQ_40", "I'll check and come right back.", "Tell him that it would be hard"))
		{
			case 1:
				await dialog.Msg("CORAL_44_2_SQ_40_AG");
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

		await dialog.Msg("CORAL_44_2_SQ_40_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

