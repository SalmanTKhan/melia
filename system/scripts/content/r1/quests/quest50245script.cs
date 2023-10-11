//--- Melia Script -----------------------------------------------------------
// Spell Absorption [Enchanter Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Enchanter Master.
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

[QuestScript(50245)]
public class Quest50245Script : QuestScript
{
	protected override void Load()
	{
		SetId(50245);
		SetName("Spell Absorption [Enchanter Advancement]");
		SetDescription("Talk with the Enchanter Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("ENCHANTER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("ENCHANTER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_ENCHANTER_8_1_START1", "JOB_ENCHANTER_8_1", "I don't have the nerve to take the test.", "I don't have the nerve to take the test."))
		{
			case 1:
				await dialog.Msg("JOB_ENCHANTER_8_1_AGREE1");
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

		await dialog.Msg("JOB_ENCHANTER_8_1_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

