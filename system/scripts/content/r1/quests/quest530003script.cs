//--- Melia Script -----------------------------------------------------------
// [Repetition] Salvation - Challenge
//--- Description -----------------------------------------------------------
// Quest to Clear Challenge Mode 80 times{nl}You can proceed with the Field Challenge (Solo) from stage 3 and above..
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

[QuestScript(530003)]
public class Quest530003Script : QuestScript
{
	protected override void Load()
	{
		SetId(530003);
		SetName("[Repetition] Salvation - Challenge");
		SetDescription("Clear Challenge Mode 80 times{nl}You can proceed with the Field Challenge (Solo) from stage 3 and above.");

		AddPrerequisite(new LevelPrerequisite(458));
		AddPrerequisite(new CompletedPrerequisite("REPUTATION_OPEN_QUEST"), new CompletedPrerequisite("P_R_EP13_1"), new CompletedPrerequisite("P_R_EP13_2"));

		AddReward(new ItemReward("reputation_Coin", 20000));

		AddDialogHook("EP13_WEEK_REPUTATION_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

