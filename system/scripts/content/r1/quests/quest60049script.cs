//--- Melia Script -----------------------------------------------------------
// A Dead End (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with Member Alina.
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

[QuestScript(60049)]
public class Quest60049Script : QuestScript
{
	protected override void Load()
	{
		SetId(60049);
		SetName("A Dead End (3)");
		SetDescription("Talk with Member Alina");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM311_SQ_07_TRACK", 8000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM311_SQ_06"));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1640));

		AddDialogHook("PILGRIM311_ALINA", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM311_ALINA_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM311_SQ_07_01", "PILGRIM311_SQ_07", "Let's go", "Let's watch the situation first"))
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

