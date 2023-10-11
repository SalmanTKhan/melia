//--- Melia Script -----------------------------------------------------------
// Laima's Spinning Wheel (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Laima's Spinning Wheel.
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

[QuestScript(72251)]
public class Quest72251Script : QuestScript
{
	protected override void Load()
	{
		SetId(72251);
		SetName("Laima's Spinning Wheel (3)");
		SetDescription("Talk to Laima's Spinning Wheel");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CASTLE102_MQ_04_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(436));
		AddPrerequisite(new CompletedPrerequisite("CASTLE102_MQ_03"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("Vis", 25288));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 17));

		AddDialogHook("CASTLE102_RAIMA_WHEEL", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE102_RAIMA_WHEEL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE102_MQ_04_DLG01", "CASTLE102_MQ_04", "I will do it", "Give me some time"))
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

		await dialog.Msg("CASTLE102_MQ_04_DLG04");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

