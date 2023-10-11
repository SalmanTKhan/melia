//--- Melia Script -----------------------------------------------------------
// Finale
//--- Description -----------------------------------------------------------
// Quest to Defeat Slogutis.
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

[QuestScript(91210)]
public class Quest91210Script : QuestScript
{
	protected override void Load()
	{
		SetId(91210);
		SetName("Finale");
		SetDescription("Defeat Slogutis");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP15_2_D_NICOPOLIS_2_MQ_6_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(495));
		AddPrerequisite(new CompletedPrerequisite("EP15_2_D_NICOPOLIS_2_MQ_5"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("EP15_2_D_NICOPOLIS_2_MQ_6_END", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

