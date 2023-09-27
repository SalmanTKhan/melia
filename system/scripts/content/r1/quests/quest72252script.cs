//--- Melia Script -----------------------------------------------------------
// Laima's Spinning Wheel (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Laima's Spinning Wheel.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;
using Melia.Shared.Tos.Const;

[QuestScript(72252)]
public class Quest72252Script : QuestScript
{
	protected override void Load()
	{
		SetId(72252);
		SetName("Laima's Spinning Wheel (4)");
		SetDescription("Talk to Laima's Spinning Wheel");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CASTLE102_MQ_05_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(436));
		AddPrerequisite(new CompletedPrerequisite("CASTLE102_MQ_04"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));

		AddDialogHook("CASTLE102_RAIMA_WHEEL", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_MAINSTREAM_NERINGA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE102_MQ_05_DLG01", "CASTLE102_MQ_05", "Alright", "That sounds dangerous"))
		{
			case 1:
				dialog.HideNPC("CASTLE102_RAIMA_WHEEL");
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

		await dialog.Msg("CASTLE102_MQ_05_DLG09");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

