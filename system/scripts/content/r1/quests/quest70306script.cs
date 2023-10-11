//--- Melia Script -----------------------------------------------------------
// A Blessed Start [Priest Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Submaster.
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

[QuestScript(70306)]
public class Quest70306Script : QuestScript
{
	protected override void Load()
	{
		SetId(70306);
		SetName("A Blessed Start [Priest Advancement]");
		SetDescription("Talk with Priest Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("JOB_2_PRIEST_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_PRIEST_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_PRIEST2_1_1", "JOB_2_PRIEST2", "Ask what you should prepare", "I don't think that'll be necessary"))
		{
			case 1:
				await dialog.Msg("JOB_2_PRIEST2_1_2");
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

