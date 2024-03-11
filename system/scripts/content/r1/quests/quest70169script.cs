//--- Melia Script -----------------------------------------------------------
// Start of a New Chase
//--- Description -----------------------------------------------------------
// Quest to Talk to the abbot.
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

[QuestScript(70169)]
public class Quest70169Script : QuestScript
{
	protected override void Load()
	{
		SetId(70169);
		SetName("Start of a New Chase");
		SetDescription("Talk to the abbot");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBEY39_4_MQ09_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(183));
		AddPrerequisite(new CompletedPrerequisite("ABBEY39_4_MQ09"));

		AddReward(new ExpReward(1884006, 1884006));
		AddReward(new ItemReward("expCard9", 5));
		AddReward(new ItemReward("Vis", 5673));

		AddDialogHook("ABBEY394_MQ_08", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY394_MQ_10_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY39_4_MQ_10_1", "ABBEY39_4_MQ10", "I will chase Ebonypawn", "I can only help so much"))
		{
			case 1:
				dialog.UnHideNPC("ABBEY394_MQ_10");
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

		await dialog.Msg("ABBEY39_4_MQ_10_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

