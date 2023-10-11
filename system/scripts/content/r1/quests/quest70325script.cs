//--- Melia Script -----------------------------------------------------------
// Purification by Fire [Krivis Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Krivis Submaster.
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

[QuestScript(70325)]
public class Quest70325Script : QuestScript
{
	protected override void Load()
	{
		SetId(70325);
		SetName("Purification by Fire [Krivis Advancement]");
		SetDescription("Talk to the Krivis Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("JOB_2_KRIVIS_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_KRIVIS_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_KRIVIS4_1_1", "JOB_2_KRIVIS4", "All prepared", "Give me some time"))
		{
			case 1:
				await dialog.Msg("JOB_2_KRIVIS4_1_2");
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

