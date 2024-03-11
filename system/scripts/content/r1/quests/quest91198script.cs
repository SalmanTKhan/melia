//--- Melia Script -----------------------------------------------------------
// Thick Dark Energy
//--- Description -----------------------------------------------------------
// Quest to Talk to Nicopolis Guard.
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

[QuestScript(91198)]
public class Quest91198Script : QuestScript
{
	protected override void Load()
	{
		SetId(91198);
		SetName("Thick Dark Energy");
		SetDescription("Talk to Nicopolis Guard");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_2_D_NICOPOLIS_1_MQ_2_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(490));
		AddPrerequisite(new CompletedPrerequisite("EP15_2_D_NICOPOLIS_1_MQ_1"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("EP15_2_D_NICOPOLIS_1_MQ_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_2_D_NICO_AUSIRINE_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_2_D_NICOPOLIS_1_MQ_2_DLG1", "EP15_2_D_NICOPOLIS_1_MQ_2", "I'm a Revelator.", "Let's prepare more."))
		{
			case 1:
				await dialog.Msg("EP15_2_D_NICOPOLIS_1_MQ_2_DLG2");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_2_D_NICOPOLIS_1_MQ_3");
	}
}

