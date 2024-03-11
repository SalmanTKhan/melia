//--- Melia Script -----------------------------------------------------------
// Laima's Spinning Wheel (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(72250)]
public class Quest72250Script : QuestScript
{
	protected override void Load()
	{
		SetId(72250);
		SetName("Laima's Spinning Wheel (2)");
		SetDescription("Talk to Neringa");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CASTLE102_MQ_03_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(436));
		AddPrerequisite(new CompletedPrerequisite("CASTLE102_MQ_01"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 17));

		AddDialogHook("EP12_MAINSTREAM_NERINGA", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE102_RAIMA_WHEEL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE102_MQ_03_DLG01", "CASTLE102_MQ_03", "I'll do it", "Ask for time to prepare"))
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

		await dialog.Msg("CASTLE102_MQ_03_DLG08");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

