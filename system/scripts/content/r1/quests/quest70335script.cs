//--- Melia Script -----------------------------------------------------------
// Learn, Accustom and Apply [Bokor Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with Bokor Submaster.
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

[QuestScript(70335)]
public class Quest70335Script : QuestScript
{
	protected override void Load()
	{
		SetId(70335);
		SetName("Learn, Accustom and Apply [Bokor Advancement]");
		SetDescription("Talk with Bokor Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 50 Red Tree Ambulo(s) or Rusty Old Hook(s) or Lichenclops Mage(s)", new KillObjective(50, 57279, 57282, 57647));

		AddDialogHook("JOB_2_BOKOR_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_BOKOR_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_BOKOR5_1_1", "JOB_2_BOKOR5", "I'll go and defeat it right away", "That's a little too much for me"))
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

