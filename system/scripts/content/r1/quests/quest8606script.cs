//--- Melia Script -----------------------------------------------------------
// The Watcher's Potential (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Rikke.
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

[QuestScript(8606)]
public class Quest8606Script : QuestScript
{
	protected override void Load()
	{
		SetId(8606);
		SetName("The Watcher's Potential (2)");
		SetDescription("Talk to Watcher Rikke");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "GELE574_MQ_06_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(35));
		AddPrerequisite(new CompletedPrerequisite("GELE574_MQ_05"));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 490));

		AddDialogHook("GELE574_REIKE", "BeforeStart", BeforeStart);
		AddDialogHook("GELE574_REIKE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE574_MQ_06_01", "GELE574_MQ_06", "Trust him one more time", "I will not be fooled again."))
		{
			case 1:
				dialog.UnHideNPC("GELE574_MQ_06");
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

		await dialog.Msg("GELE574_MQ_06_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

