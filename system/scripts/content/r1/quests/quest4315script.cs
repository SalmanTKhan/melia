//--- Melia Script -----------------------------------------------------------
// Historian Kepeck (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Liaison Officer Niels.
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

[QuestScript(4315)]
public class Quest4315Script : QuestScript
{
	protected override void Load()
	{
		SetId(4315);
		SetName("Historian Kepeck (1)");
		SetDescription("Talk to Liaison Officer Niels");

		AddPrerequisite(new LevelPrerequisite(58));

		AddDialogHook("ROKAS_24_NEALS", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS24_MIRTA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_DIALOG2_select1", "ROKAS24_DIALOG2", "Sure, I'll help", "I'm busy"))
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


		return HookResult.Break;
	}
}

