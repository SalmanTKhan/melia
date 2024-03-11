//--- Melia Script -----------------------------------------------------------
// Cleaning the Pit
//--- Description -----------------------------------------------------------
// Quest to Talk to Merchant Simonas.
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

[QuestScript(90021)]
public class Quest90021Script : QuestScript
{
	protected override void Load()
	{
		SetId(90021);
		SetName("Cleaning the Pit");
		SetDescription("Talk to Merchant Simonas");

		AddPrerequisite(new LevelPrerequisite(232));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_1_SQ_1"));

		AddObjective("kill0", "Kill 12 Greentoshell(s) or Blue Lapasape Mage(s) or Blue Terra Imp(s)", new KillObjective(12, 41316, 57943, 57950));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 8352));

		AddDialogHook("CORAL_32_1_MERCHANT1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_1_MERCHANT1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_1_SQ_2_ST", "CORAL_32_1_SQ_2", "I'll help you", "Unfortunately, it's going to be hard"))
		{
			case 1:
				await dialog.Msg("CORAL_32_1_SQ_2_AG");
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

		// Func/SCR_CORAL_32_1_SQ_3_RUN1;
		await dialog.Msg("CORAL_32_1_SQ_2_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

