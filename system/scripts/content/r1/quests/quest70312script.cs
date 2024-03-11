//--- Melia Script -----------------------------------------------------------
// The Gesture of Salvation [Cleric Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with Cleric Submaster.
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

[QuestScript(70312)]
public class Quest70312Script : QuestScript
{
	protected override void Load()
	{
		SetId(70312);
		SetName("The Gesture of Salvation [Cleric Advancement]");
		SetDescription("Talk with Cleric Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("JOB_2_CLERIC_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_CLERIC_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_CLERIC3_1_1", "JOB_2_CLERIC3", "What should I do", "The others already started to help"))
		{
			case 1:
				await dialog.Msg("JOB_2_CLERIC3_1_2");
				dialog.UnHideNPC("JOB_2_CLERIC3_PATIENT");
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

