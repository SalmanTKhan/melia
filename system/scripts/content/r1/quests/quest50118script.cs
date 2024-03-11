//--- Melia Script -----------------------------------------------------------
// The Rescue (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Traveling Merchant Rose.
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

[QuestScript(50118)]
public class Quest50118Script : QuestScript
{
	protected override void Load()
	{
		SetId(50118);
		SetName("The Rescue (2)");
		SetDescription("Talk to Traveling Merchant Rose");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBAY_64_1_MQ020_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_1_MQ010"));

		AddObjective("kill0", "Kill 4 Canyon Area Device 5(s)", new KillObjective(4, MonsterId.Npc_Rokas_6));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Drug_SP1_Q", 45));
		AddReward(new ItemReward("Vis", 675));

		AddDialogHook("ABBEY641_ROZE01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY641_MONK01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_1_MQ020_startnpc01", "ABBAY_64_1_MQ020", "We should hurry", "Look for another way"))
		{
			case 1:
				await dialog.Msg("ABBAY_64_1_MQ020_AG");
				dialog.HideNPC("ABBEY641_ROZE01");
				await dialog.Msg("FadeOutIN/1000");
				dialog.UnHideNPC("ABBEY641_ROZE02");
				dialog.UnHideNPC("ABBEY641_MONK01");
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

