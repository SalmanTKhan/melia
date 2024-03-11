//--- Melia Script -----------------------------------------------------------
// Worshiping Goddess Statues [Krivis Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Krivis Submaster.
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

[QuestScript(70313)]
public class Quest70313Script : QuestScript
{
	protected override void Load()
	{
		SetId(70313);
		SetName("Worshiping Goddess Statues [Krivis Advancement]");
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

		switch (await dialog.Select("JOB_2_KRIVIS3_1_1", "JOB_2_KRIVIS3", "Ask where to go", "I am doing the praying on normal days"))
		{
			case 1:
				await dialog.Msg("JOB_2_KRIVIS3_1_2");
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

