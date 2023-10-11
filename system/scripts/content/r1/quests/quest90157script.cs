//--- Melia Script -----------------------------------------------------------
//  Make It Doubly Sure [Lancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Lancer Master.
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

[QuestScript(90157)]
public class Quest90157Script : QuestScript
{
	protected override void Load()
	{
		SetId(90157);
		SetName(" Make It Doubly Sure [Lancer Advancement]");
		SetDescription("Talk with the Lancer Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_LANCER_8_1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(285));

		AddObjective("kill0", "Kill 4 Rhodenag(s) or Rhodenabean(s)", new KillObjective(4, 58539, 58538));

		AddDialogHook("LANCER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("LANCER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_LANCER_8_1_ST", "JOB_LANCER_8_1", "I was born ready.", "I'm not so sure about it"))
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
			await dialog.Msg("JOB_LANCER_8_1_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

