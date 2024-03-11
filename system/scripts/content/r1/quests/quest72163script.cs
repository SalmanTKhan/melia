//--- Melia Script -----------------------------------------------------------
// Make it Certain
//--- Description -----------------------------------------------------------
// Quest to Talk with the Lancer Master.
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

[QuestScript(72163)]
public class Quest72163Script : QuestScript
{
	protected override void Load()
	{
		SetId(72163);
		SetName("Make it Certain");
		SetDescription("Talk with the Lancer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "MASTER_LANCER_1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(285));

		AddObjective("kill0", "Kill 8 Rhodenag(s) or Rhodenabean(s)", new KillObjective(8, 58539, 58538));

		AddReward(new ItemReward("Point_Stone_100_Q", 2));

		AddDialogHook("LANCER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("LANCER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MASTER_LANCER1_DLG1", "MASTER_LANCER1", "You can tell me. ", "You saw the wrong person."))
		{
			case 1:
				await dialog.Msg("JOB_LANCER_8_1_AG");
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

		if (character.Inventory.HasItem("JOB_LANCER_8_1_ITEM", 1))
		{
			character.Inventory.RemoveItem("JOB_LANCER_8_1_ITEM", 1);
			await dialog.Msg("MASTER_LANCER1_DLG2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

