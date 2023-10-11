//--- Melia Script -----------------------------------------------------------
// Following the Light
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

[QuestScript(30050)]
public class Quest30050Script : QuestScript
{
	protected override void Load()
	{
		SetId(30050);
		SetName("Following the Light");
		SetDescription("Speak with Mardas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN_10_MQ_02_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN_10_MQ_01"));

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1026));

		AddDialogHook("KATYN_10_NPC_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_10_MQ_02_select", "KATYN_10_MQ_02", "I will follow it", "About the Owl Sculpture", "Looks dangerous. I'm out"))
		{
			case 1:
				await dialog.Msg("KATYN_10_MQ_02_agree");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("KATYN_10_MQ_02_add");
				break;
		}

		return HookResult.Break;
	}
}

