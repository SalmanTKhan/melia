//--- Melia Script -----------------------------------------------------------
// With A Partner [Cataphract Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cataphract Master.
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

[QuestScript(70334)]
public class Quest70334Script : QuestScript
{
	protected override void Load()
	{
		SetId(70334);
		SetName("With A Partner [Cataphract Advancement]");
		SetDescription("Talk to the Cataphract Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("JOB_2_CATAPHRACT_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_CATAPHRACT_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_CATAPHRACT5_1_1", "JOB_2_CATAPHRACT5", "They're in perfect condition", "The last thing I need is another task"))
		{
			case 1:
				await dialog.Msg("JOB_2_CATAPHRACT5_1_2");
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

