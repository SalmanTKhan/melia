//--- Melia Script -----------------------------------------------------------
// Path of the Healer [Cleric Advancement](1)
//--- Description -----------------------------------------------------------
// Quest to Go to the Cleric Master.
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

[QuestScript(17310)]
public class Quest17310Script : QuestScript
{
	protected override void Load()
	{
		SetId(17310);
		SetName("Path of the Healer [Cleric Advancement](1)");
		SetDescription("Go to the Cleric Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("MASTER_CLERIC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_CENT4_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CLERIC4_1_ST", "JOB_CLERIC4_1", "I'll go to the Centurion Master", "It's too far away"))
		{
			case 1:
				await dialog.Msg("JOB_CLERIC4_1_AC");
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

		await dialog.Msg("JOB_CLERIC4_1_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_CLERIC4_2");
	}
}

