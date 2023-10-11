//--- Melia Script -----------------------------------------------------------
// Two Seal Stones (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Edmundas.
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

[QuestScript(91184)]
public class Quest91184Script : QuestScript
{
	protected override void Load()
	{
		SetId(91184);
		SetName("Two Seal Stones (1)");
		SetDescription("Talk to Edmundas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_1_F_ABBEY_3_3_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(487));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY_3_2"));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("AD3_FOLLOWNPC_CHAT", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_F_ABBEY_3_3_DLG1", "EP15_1_F_ABBEY_3_3", "I'll go check it out.", "It's dangerous, don't touch it."))
		{
			case 1:
				// Func/SCR_EP15_1_FABBEY3_3_scroll_RUN;
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

