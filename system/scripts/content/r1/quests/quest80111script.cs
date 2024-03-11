//--- Melia Script -----------------------------------------------------------
// Restrain to Protect (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kabbalist Lutas.
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

[QuestScript(80111)]
public class Quest80111Script : QuestScript
{
	protected override void Load()
	{
		SetId(80111);
		SetName("Restrain to Protect (1)");
		SetDescription("Talk to Kabbalist Lutas");

		AddPrerequisite(new LevelPrerequisite(226));
		AddPrerequisite(new CompletedPrerequisite("CORAL_35_2_SQ_11"));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8136));

		AddDialogHook("CORAL_35_2_LUTAS", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_35_2_LUTAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_35_2_SQ_13_start", "CORAL_35_2_SQ_13", "I'll help you, but what if other people get caught in it?", "I'm busy now"))
		{
			case 1:
				await dialog.Msg("CORAL_35_2_SQ_13_AG");
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

		await dialog.Msg("CORAL_35_2_SQ_13_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

