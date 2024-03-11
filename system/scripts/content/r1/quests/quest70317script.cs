//--- Melia Script -----------------------------------------------------------
// Tools and Creations [Dievdirbys Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the blacksmith at Orsha.
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

[QuestScript(70317)]
public class Quest70317Script : QuestScript
{
	protected override void Load()
	{
		SetId(70317);
		SetName("Tools and Creations [Dievdirbys Advancement] (2)");
		SetDescription("Talk to the blacksmith at Orsha");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("JOB_2_DIEVDIRBYS3_1"));

		AddObjective("collect0", "Collect 20 Ore Crystal(s)", new CollectItemObjective("JOB_2_DIEVDIRBYS3_ITEM1", 20));
		AddDrop("JOB_2_DIEVDIRBYS3_ITEM1", 7.5f, "Sec_Grummer");

		AddDialogHook("ORSHA_BLACKSMITH", "BeforeStart", BeforeStart);
		AddDialogHook("ORSHA_BLACKSMITH", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_DIEVDIRBYS3_2_1", "JOB_2_DIEVDIRBYS3_2", "I'll go there", "I will wait until the materials arrive"))
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

