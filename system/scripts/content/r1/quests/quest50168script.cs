//--- Melia Script -----------------------------------------------------------
// Village Curse (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Villager Argis.
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

[QuestScript(50168)]
public class Quest50168Script : QuestScript
{
	protected override void Load()
	{
		SetId(50168);
		SetName("Village Curse (3)");
		SetDescription("Talk to Villager Argis");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "TABLELAND_72_SQ4_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(246));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_72_SQ3"));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("expCard12", 1));
		AddReward(new ItemReward("Vis", 9102));

		AddDialogHook("TABLE72_PEAPLE2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE72_PEAPLE1_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_72_SQ4_startnpc1", "TABLELAND_72_SQ4", "I'll go set up the bomb.", "I need some time to prepare"))
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

		await dialog.Msg("TABLELAND_72_SQ4_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

