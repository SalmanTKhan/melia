//--- Melia Script -----------------------------------------------------------
// The Rescue (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Traveling Merchant Rose.
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

[QuestScript(50121)]
public class Quest50121Script : QuestScript
{
	protected override void Load()
	{
		SetId(50121);
		SetName("The Rescue (5)");
		SetDescription("Talk to Traveling Merchant Rose");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBAY_64_1_MQ050_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_1_MQ040"));

		AddObjective("kill0", "Kill 1 Mummyghast", new KillObjective(1, MonsterId.Boss_Mummyghast_Q1));

		AddReward(new ExpReward(211050, 211050));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 5400));

		AddDialogHook("ABBEY641_ROZE05", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY641_ROZE03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_1_MQ050_startnpc01", "ABBAY_64_1_MQ050", "I'll help you", "It's still dangerous because of the demons' barrier"))
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
}

