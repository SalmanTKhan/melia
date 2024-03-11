//--- Melia Script -----------------------------------------------------------
// Laima's Spinning Wheel (5)
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

[QuestScript(72253)]
public class Quest72253Script : QuestScript
{
	protected override void Load()
	{
		SetId(72253);
		SetName("Laima's Spinning Wheel (5)");
		SetDescription("Talk to Neringa");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CASTLE102_MQ_06_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(436));
		AddPrerequisite(new CompletedPrerequisite("CASTLE102_MQ_05"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));

		AddDialogHook("EP12_MAINSTREAM_NERINGA", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_MAINSTREAM_NERINGA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE102_MQ_06_DLG01", "CASTLE102_MQ_06", "It's something I must do", "It is unstable at the moment"))
		{
			case 1:
				dialog.HideNPC("ANOTHER_SPACE_PORTAL");
				dialog.HideNPC("CASTLE102_AUSTEJA_02");
				dialog.HideNPC("CASTLE102_MQ_06_VIVORA");
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

		await dialog.Msg("CASTLE102_MQ_06_DLG10");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

