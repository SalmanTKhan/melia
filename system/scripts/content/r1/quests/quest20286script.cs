//--- Melia Script -----------------------------------------------------------
// A Drowsy Scent
//--- Description -----------------------------------------------------------
// Quest to Talk to Andale Village Headman.
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

[QuestScript(20286)]
public class Quest20286Script : QuestScript
{
	protected override void Load()
	{
		SetId(20286);
		SetName("A Drowsy Scent");
		SetDescription("Talk to Andale Village Headman");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "HUEVILLAGE_58_3_MQ04_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(52));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_3_MQ03"));

		AddObjective("kill0", "Kill 3 Red Banshee(s)", new KillObjective(3, MonsterId.Banshee_Pink));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));
		AddReward(new ItemReward("Vis", 5616));

		AddDialogHook("HUEVILLAGE_58_3_MQ03_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_3_MQ04_TO_HUE1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("HUEVILLAGE_58_3_MQ04_select01", "HUEVILLAGE_58_3_MQ04", "I'll use the bomb", "I will prepare myself for a while"))
		{
			case 1:
				await dialog.Msg("HUEVILLAGE_58_3_MQ04_agree");
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

		// Func/SCR_HUEVILLAGE_58_3_MQ04_SUCC_BOOK;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

