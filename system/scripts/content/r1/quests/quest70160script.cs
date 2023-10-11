//--- Melia Script -----------------------------------------------------------
// Mission to Retake the Monastery (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Senior Monk Goss.
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

[QuestScript(70160)]
public class Quest70160Script : QuestScript
{
	protected override void Load()
	{
		SetId(70160);
		SetName("Mission to Retake the Monastery (1)");
		SetDescription("Talk to Senior Monk Goss");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBEY39_4_MQ01_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(183));
		AddPrerequisite(new CompletedPrerequisite("THORN39_3_MQ06"));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5673));

		AddDialogHook("ABBEY394_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY394_MQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY39_4_MQ_01_1", "ABBEY39_4_MQ01", "All prepared", "I need some more time to prepare."))
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


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ABBEY39_4_MQ02");
	}
}

