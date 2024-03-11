//--- Melia Script -----------------------------------------------------------
// Mission to Retake the Monastery (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Senior Monk Goss.
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

[QuestScript(70162)]
public class Quest70162Script : QuestScript
{
	protected override void Load()
	{
		SetId(70162);
		SetName("Mission to Retake the Monastery (3)");
		SetDescription("Talk to Senior Monk Goss");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBEY39_4_MQ03_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(183));
		AddPrerequisite(new CompletedPrerequisite("ABBEY39_4_MQ02"));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5673));

		AddDialogHook("ABBEY394_MQ_03", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY39_4_MQ_03_1", "ABBEY39_4_MQ03", "Let's go", "Let's take a rest for a while"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ABBEY39_4_MQ04");
	}
}

