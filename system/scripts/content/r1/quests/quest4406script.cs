//--- Melia Script -----------------------------------------------------------
// Truth and Spirit
//--- Description -----------------------------------------------------------
// Quest to Talk to the Old Owl Sculpture.
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

[QuestScript(4406)]
public class Quest4406Script : QuestScript
{
	protected override void Load()
	{
		SetId(4406);
		SetName("Truth and Spirit");
		SetDescription("Talk to the Old Owl Sculpture");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN23_Q_16_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(123));
		AddPrerequisite(new CompletedPrerequisite("THORN23_Q_15"));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 3075));

		AddDialogHook("THORN23_OWL2", "BeforeStart", BeforeStart);
		AddDialogHook("THORN23_OWL2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN23_Q_16_select1", "THORN23_Q_16", "I've met the soldiers", "Tell him that he doesn't have to know"))
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

		await dialog.Msg("THORN23_Q_16_succ1");
		// Func/SOLDIER_ALL_HIDE;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

