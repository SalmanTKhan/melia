//--- Melia Script -----------------------------------------------------------
// Dark Barrier
//--- Description -----------------------------------------------------------
// Quest to Enter Demonic Dwellings.
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

[QuestScript(91205)]
public class Quest91205Script : QuestScript
{
	protected override void Load()
	{
		SetId(91205);
		SetName("Dark Barrier");
		SetDescription("Enter Demonic Dwellings");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_2_D_NICOPOLIS_2_MQ_1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(493));
		AddPrerequisite(new CompletedPrerequisite("EP15_2_D_NICOPOLIS_1_MQ_8"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("EP15_2_D_NICO_2_AUSIRINE_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_2_D_NICOPOLIS_2_MQ_2");
	}
}

