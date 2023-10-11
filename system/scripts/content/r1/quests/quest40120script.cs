//--- Melia Script -----------------------------------------------------------
// Needing the Nutritious Tonic (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Stepas.
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

[QuestScript(40120)]
public class Quest40120Script : QuestScript
{
	protected override void Load()
	{
		SetId(40120);
		SetName("Needing the Nutritious Tonic (1)");
		SetDescription("Talk to Soldier Stepas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FARM47_4_SQ_060_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(84));

		AddReward(new ExpReward(274320, 274320));
		AddReward(new ItemReward("expCard5", 6));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("FARM47_STEPAS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_STEPAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_4_SQ_060_ST", "FARM47_4_SQ_060", "I'll help you", "About the relationship of guards and farmers", "Ignore"))
		{
			case 1:
				await dialog.Msg("FARM47_4_SQ_060_AC");
				dialog.UnHideNPC("FARM47_SCORPIO");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("FARM47_4_SQ_060_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM47_4_SQ_060_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

