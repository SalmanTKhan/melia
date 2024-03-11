//--- Melia Script -----------------------------------------------------------
// Clear the Corruption (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Elder Aloizard.
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

[QuestScript(90012)]
public class Quest90012Script : QuestScript
{
	protected override void Load()
	{
		SetId(90012);
		SetName("Clear the Corruption (3)");
		SetDescription("Talk to Elder Aloizard");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_84_MQ_02"));

		AddDialogHook("3CMLAKE_84_OLDMAN", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_84_HUNTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE_84_MQ_03_DLG_01", "F_3CMLAKE_84_MQ_03", "I'll do it", "Tell him that you need some time to think"))
		{
			case 1:
				await dialog.Msg("3CMLAKE_84_MQ_03_DLG_02");
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

