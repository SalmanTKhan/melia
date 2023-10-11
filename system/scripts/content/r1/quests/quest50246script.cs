//--- Melia Script -----------------------------------------------------------
// Heretics Beware [Inquistor Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Inquisitor Master.
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

[QuestScript(50246)]
public class Quest50246Script : QuestScript
{
	protected override void Load()
	{
		SetId(50246);
		SetName("Heretics Beware [Inquistor Advancement]");
		SetDescription("Talk with the Inquisitor Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("INQUISITOR_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("INQUISITOR_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_INQUGITOR_8_1_START", "JOB_INQUGITOR_8_1", "I can fully take up the duties and authorities as an Inquisitor", "I refuse to take the authorities nor the duties it entails"))
		{
			case 1:
				await dialog.Msg("JOB_INQUGITOR_8_1_AGREE1");
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

		await dialog.Msg("JOB_INQUGITOR_8_1_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

