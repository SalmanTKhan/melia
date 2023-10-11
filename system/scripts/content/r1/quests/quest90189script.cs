//--- Melia Script -----------------------------------------------------------
// Followers of Goddess Jurate(2)
//--- Description -----------------------------------------------------------
// Quest to Speak with Revelator Pudhin.
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

[QuestScript(90189)]
public class Quest90189Script : QuestScript
{
	protected override void Load()
	{
		SetId(90189);
		SetName("Followers of Goddess Jurate(2)");
		SetDescription("Speak with Revelator Pudhin");

		AddPrerequisite(new LevelPrerequisite(327));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_1_SQ_10"));

		AddDialogHook("CORAL_44_1_MAN1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_1_MAN1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_1_SQ_20_ST", "CORAL_44_1_SQ_20", "Yes", "No"))
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

		await dialog.Msg("CORAL_44_1_SQ_20_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

