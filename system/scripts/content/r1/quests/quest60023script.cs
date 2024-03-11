//--- Melia Script -----------------------------------------------------------
// The Dimensional Crack (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Vakarine.
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

[QuestScript(60023)]
public class Quest60023Script : QuestScript
{
	protected override void Load()
	{
		SetId(60023);
		SetName("The Dimensional Crack (1)");
		SetDescription("Talk to Goddess Vakarine");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "VPRISON515_MQ_01_TRACK");

		AddPrerequisite(new LevelPrerequisite(163));
		AddPrerequisite(new CompletedPrerequisite("VPRISON513_MQ_05"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));

		AddDialogHook("VPRISON515_MQ_VAKARINE", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON515_MQ_VAKARINE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON515_MQ_01_01", "VPRISON515_MQ_01", "Let's begin the ritual", "I'm not ready yet"))
		{
			case 1:
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

		await dialog.Msg("VPRISON515_MQ_01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

