//--- Melia Script -----------------------------------------------------------
// Missing Herbalist (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Herbalist Ash.
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

[QuestScript(90179)]
public class Quest90179Script : QuestScript
{
	protected override void Load()
	{
		SetId(90179);
		SetName("Missing Herbalist (2)");
		SetDescription("Talk to Herbalist Ash");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "LOWLV_GREEN_SQ_30_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("LOWLV_GREEN_SQ_20"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("misc_ore17", 1));
		AddReward(new ItemReward("misc_scrollskulp", 1));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("BRACKEN632_PEAPLE01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN632_PEAPLE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LOWLV_GREEN_SQ_30_ST", "LOWLV_GREEN_SQ_30", "Alright", "That's going to be difficult, sorry."))
		{
			case 1:
				await dialog.Msg("LOWLV_GREEN_SQ_30_AG");
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


		return HookResult.Break;
	}
}

