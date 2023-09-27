//--- Melia Script -----------------------------------------------------------
// Intruders of the Ruins (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(72255)]
public class Quest72255Script : QuestScript
{
	protected override void Load()
	{
		SetId(72255);
		SetName("Intruders of the Ruins (1)");
		SetDescription("Talk to Neringa");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "DCAPITAL53_1_MQ_02_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(441));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL53_1_MQ_01"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("Vis", 26019));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 17));

		AddDialogHook("EP12_MAINSTREAM_NERINGA", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_MAINSTREAM_NERINGA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL53_1_MQ_02_DLG01", "DCAPITAL53_1_MQ_02", "Let's go.", "Say it's probably nothing"))
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

		await dialog.Msg("DCAPITAL53_1_MQ_02_DLG04");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

