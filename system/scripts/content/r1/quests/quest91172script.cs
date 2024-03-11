//--- Melia Script -----------------------------------------------------------
// Following the Memory
//--- Description -----------------------------------------------------------
// Quest to Talk to Rose.
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

[QuestScript(91172)]
public class Quest91172Script : QuestScript
{
	protected override void Load()
	{
		SetId(91172);
		SetName("Following the Memory");
		SetDescription("Talk to Rose");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_1_F_ABBEY1_8_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(480));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY1_7"));

		AddObjective("kill0", "Kill 1 Vubbas", new KillObjective(1, MonsterId.Ep15_1_Boss_Bubas));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY1_ROZE2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_F_ABBEY1_8_DLG1", "EP15_1_F_ABBEY1_8", "Alright", "I need to do some preparation."))
		{
			case 1:
				// Func/SCR_EP15_1_ABBEY1_SUMMON_ABANDON;
				dialog.HideNPC("EP15_1_FABBEY1_ROZE2");
				dialog.HideNPC("EP15_1_FABBEY1_AD2");
				await dialog.Msg("EP15_1_F_ABBEY1_8_DLG2");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

