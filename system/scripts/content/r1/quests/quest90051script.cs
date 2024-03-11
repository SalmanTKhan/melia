//--- Melia Script -----------------------------------------------------------
// Troublemaker Ridimeds (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Ruthalen.
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

[QuestScript(90051)]
public class Quest90051Script : QuestScript
{
	protected override void Load()
	{
		SetId(90051);
		SetName("Troublemaker Ridimeds (2)");
		SetDescription("Talk to Dievdirbys Ruthalen");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "KATYN_45_2_SQ_10_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(249));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_2_SQ_9"));

		AddObjective("kill0", "Kill 22 Blue Ridimed(s)", new KillObjective(22, MonsterId.Ridimed_Blue));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 9213));

		AddDialogHook("KATYN_45_2_SCULPTOR2", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_2_SCULPTOR2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_2_SQ_10_ST", "KATYN_45_2_SQ_10", "Alright", "Give me some time to prepare"))
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

		await dialog.Msg("KATYN_45_2_SQ_10_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

