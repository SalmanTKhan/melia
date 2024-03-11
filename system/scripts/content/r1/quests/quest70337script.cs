//--- Melia Script -----------------------------------------------------------
// Repairing the Goddess Statue [Dievdirbys Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Dievdirbys Submaster.
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

[QuestScript(70337)]
public class Quest70337Script : QuestScript
{
	protected override void Load()
	{
		SetId(70337);
		SetName("Repairing the Goddess Statue [Dievdirbys Advancement] (2)");
		SetDescription("Talk with Dievdirbys Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("JOB_2_DIEVDIRBYS5_1"));

		AddDialogHook("JOB_2_DIEVDIRBYS_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_DIEVDIRBYS_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_DIEVDIRBYS5_2_1", "JOB_2_DIEVDIRBYS5_2", "I'll repair the Goddess Statues.", "Give me some time to prepare"))
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

