//--- Melia Script -----------------------------------------------------------
// Brother, Then
//--- Description -----------------------------------------------------------
// Quest to Talk to Coben.
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

[QuestScript(19041)]
public class Quest19041Script : QuestScript
{
	protected override void Load()
	{
		SetId(19041);
		SetName("Brother, Then");
		SetDescription("Talk to Coben");

		AddPrerequisite(new LevelPrerequisite(107));

		AddDialogHook("REMAINS_40_DRUNK_03", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS_40_HQ_01_TB", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS_40_HQ_01_ST", "REMAINS_40_HQ_01", "I appreciate it", "I don't need it"))
		{
			case 1:
				await dialog.Msg("REMAINS_40_HQ_01_AC");
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

		await dialog.Msg("NPCAin/REMAINS_40_HQ_01_TB/OPENED/1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

