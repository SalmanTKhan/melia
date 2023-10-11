//--- Melia Script -----------------------------------------------------------
// Historian Rexipher's Research (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Historian Rexipher.
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

[QuestScript(20180)]
public class Quest20180Script : QuestScript
{
	protected override void Load()
	{
		SetId(20180);
		SetName("Historian Rexipher's Research (2)");
		SetDescription("Talk to Historian Rexipher");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS29_MQ2_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(73));
		AddPrerequisite(new CompletedPrerequisite("ROKAS29_MQ1"));

		AddObjective("kill0", "Kill 5 Zinutena(s) or Zinutekas(s)", new KillObjective(5, 401364, 57777));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("ROKAS29_SLATE2", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 1387));

		AddDialogHook("ROKAS29_MQ_REXITHER2", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS29_MQ_DEVICE2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS29_MQ2_select", "ROKAS29_MQ2", "Find the next epitaph", "I can only help so much"))
		{
			case 1:
				dialog.HideNPC("ROKAS29_MQ_REXITHER2");
				await dialog.Msg("FadeOutIN/2000");
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

