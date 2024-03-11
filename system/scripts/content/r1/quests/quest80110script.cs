//--- Melia Script -----------------------------------------------------------
// More Earth Energy
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

[QuestScript(80110)]
public class Quest80110Script : QuestScript
{
	protected override void Load()
	{
		SetId(80110);
		SetName("More Earth Energy");
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

		switch (await dialog.Select("CORAL_35_2_SQ_12_start", "CORAL_35_2_SQ_12", "Alright, I'll help you", "I'm busy now"))
		{
			case 1:
				await dialog.Msg("CORAL_35_2_SQ_12_AG");
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

		await dialog.Msg("CORAL_35_2_SQ_12_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

