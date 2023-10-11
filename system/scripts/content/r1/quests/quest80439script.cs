//--- Melia Script -----------------------------------------------------------
// An alien presence
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Serija.
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

[QuestScript(80439)]
public class Quest80439Script : QuestScript
{
	protected override void Load()
	{
		SetId(80439);
		SetName("An alien presence");
		SetDescription("Talk to Kupole Serija");
		SetTrack(QuestStatus.Progress, QuestStatus.Progress, "LIMESTONE_52_4_BLACKMAN_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(298));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_4_MQ_10"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));

		AddDialogHook("LIMESTONECAVE_52_4_SERIJA", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_4_BLACKMAN_DLG1", "LIMESTONE_52_4_MQ_BLACKMAN", "I'll have a look.", "It's probably nothing."))
		{
			case 1:
				// Func/LIMESTONE_52_4_REENTER_RUN;
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

