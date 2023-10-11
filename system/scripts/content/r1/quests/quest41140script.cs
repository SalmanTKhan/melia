//--- Melia Script -----------------------------------------------------------
// Final Conclusion (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Gedas.
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

[QuestScript(41140)]
public class Quest41140Script : QuestScript
{
	protected override void Load()
	{
		SetId(41140);
		SetName("Final Conclusion (4)");
		SetDescription("Talk to Gedas");

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_36_2_SQ_130"));

		AddReward(new ItemReward("PILGRIM_36_2_SQ_1400_ITEM_1", 1));

		AddDialogHook("PILGRIM_36_2_GEDAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_EDVINAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_36_2_SQ_140_ST", "PILGRIM_36_2_SQ_140", "I will go help Fabijus", "Let's think about this for a moment"))
		{
			case 1:
				await dialog.Msg("PILGRIM_36_2_SQ_140_AC");
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

		await dialog.Msg("PILGRIM_36_2_SQ_140_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

