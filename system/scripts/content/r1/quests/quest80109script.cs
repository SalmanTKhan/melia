//--- Melia Script -----------------------------------------------------------
// Balancing Magic Circle (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kabbalist Lutas.
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

[QuestScript(80109)]
public class Quest80109Script : QuestScript
{
	protected override void Load()
	{
		SetId(80109);
		SetName("Balancing Magic Circle (2)");
		SetDescription("Talk to Kabbalist Lutas");

		AddPrerequisite(new LevelPrerequisite(226));
		AddPrerequisite(new CompletedPrerequisite("CORAL_35_2_SQ_10"));

		AddReward(new ExpReward(4869207, 4869207));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 8136));

		AddDialogHook("CORAL_35_2_LUTAS_4", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_35_2_LUTAS_4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_35_2_SQ_11_start", "CORAL_35_2_SQ_11", "Leave it to me", "I can't go alone."))
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

		await dialog.Msg("CORAL_35_2_SQ_11_succ");
		// Func/CORAL_35_2_HIDE_FUNC;
		dialog.HideNPC("CORAL_35_2_LUTAS_4");
		dialog.UnHideNPC("CORAL_35_2_LUTAS");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

