//--- Melia Script -----------------------------------------------------------
// Respect Your Elders
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Asel.
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

[QuestScript(90033)]
public class Quest90033Script : QuestScript
{
	protected override void Load()
	{
		SetId(90033);
		SetName("Respect Your Elders");
		SetDescription("Talk to Dievdirbys Asel");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "KATYN_45_1_SQ_3_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(245));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_1_SQ_2"));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("expCard12", 5));
		AddReward(new ItemReward("Vis", 9065));

		AddDialogHook("KATYN_45_1_AJEL1", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_1_AJEL2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_1_SQ_3_ST", "KATYN_45_1_SQ_3", "I'll escort you to where the owl sculpture is.", "I'm sorry, I don't really have time for that."))
		{
			case 1:
				await dialog.Msg("KATYN_45_1_SQ_3_AG");
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

		dialog.HideNPC("KATYN_45_1_AJEL1");
		dialog.UnHideNPC("KATYN_45_1_AJEL2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

