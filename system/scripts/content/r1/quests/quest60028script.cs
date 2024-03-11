//--- Melia Script -----------------------------------------------------------
// The Dimensional Crack (6)
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

[QuestScript(60028)]
public class Quest60028Script : QuestScript
{
	protected override void Load()
	{
		SetId(60028);
		SetName("The Dimensional Crack (6)");
		SetDescription("Talk to Goddess Vakarine");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "VPRISON515_MQ_06_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(163));
		AddPrerequisite(new CompletedPrerequisite("VPRISON515_MQ_05"), new CompletedPrerequisite("VPRISON515_MQ_04"), new CompletedPrerequisite("VPRISON515_MQ_03"));

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

		switch (await dialog.Select("VPRISON515_MQ_06_01", "VPRISON515_MQ_06", "I am ready", "Tell her that it will be ready soon"))
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
		character.Quests.Start("VPRISON515_MQ_07");
	}
}

