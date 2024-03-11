//--- Melia Script -----------------------------------------------------------
// Bokor is... [Bokor Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with Bokor Submaster.
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

[QuestScript(70315)]
public class Quest70315Script : QuestScript
{
	protected override void Load()
	{
		SetId(70315);
		SetName("Bokor is... [Bokor Advancement]");
		SetDescription("Talk with Bokor Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("JOB_2_BOKOR_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_BOKOR_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_BOKOR3_1_1", "JOB_2_BOKOR3", "I'll try and make a doll", "I am not interested"))
		{
			case 1:
				await dialog.Msg("JOB_2_BOKOR3_1_2");
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

