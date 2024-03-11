//--- Melia Script -----------------------------------------------------------
// Missing Child
//--- Description -----------------------------------------------------------
// Quest to Talk to Ohla.
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

[QuestScript(50248)]
public class Quest50248Script : QuestScript
{
	protected override void Load()
	{
		SetId(50248);
		SetName("Missing Child");
		SetDescription("Talk to Ohla");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WHITETREES56_1_SQ1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(327));

		AddObjective("kill0", "Kill 8 Flowlevi(s) or Flowlon(s)", new KillObjective(8, 58564, 58563));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 15369));

		AddDialogHook("WHITETREES561_SUBQ_NPC1_1", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES561_SUBQ_NPC1_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WHITETREES561_SUBQ1_START1", "WHITETREES56_1_SQ1", "So, where should I search?", "There surely must be someone else you could ask for help."))
		{
			case 1:
				await dialog.Msg("WHITETREES561_SUBQ1_AGREE1");
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

		// Func/WHITETREES561_SUBQ1_COM;
		dialog.UnHideNPC("WHITETREES561_SUBQ_NPC1_2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

