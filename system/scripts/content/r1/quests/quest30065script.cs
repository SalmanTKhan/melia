//--- Melia Script -----------------------------------------------------------
// Away From the Watch
//--- Description -----------------------------------------------------------
// Quest to Speak with Mardas.
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

[QuestScript(30065)]
public class Quest30065Script : QuestScript
{
	protected override void Load()
	{
		SetId(30065);
		SetName("Away From the Watch");
		SetDescription("Speak with Mardas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN_12_MQ_06_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN_12_MQ_05"));

		AddReward(new ExpReward(126630, 126630));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("KATYN_12_NPC_02", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_12_MQ_06_select", "KATYN_12_MQ_06", "Trust me", "I need some time to prepare"))
		{
			case 1:
				await dialog.Msg("KATYN_12_MQ_06_agree");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

