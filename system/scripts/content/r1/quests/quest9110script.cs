//--- Melia Script -----------------------------------------------------------
// Historian Colin's Favor
//--- Description -----------------------------------------------------------
// Quest to Talk to Historian Colin.
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

[QuestScript(9110)]
public class Quest9110Script : QuestScript
{
	protected override void Load()
	{
		SetId(9110);
		SetName("Historian Colin's Favor");
		SetDescription("Talk to Historian Colin");

		AddPrerequisite(new LevelPrerequisite(1));

		AddDialogHook("ROKAS30_COLLIN", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS30_COLLIN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS_30_HQ_01_select01", "ROKAS_30_HQ_01", "I will burn the oration and comfort the souls", "Decline"))
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

		await dialog.Msg("ROKAS_30_HQ_01_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

