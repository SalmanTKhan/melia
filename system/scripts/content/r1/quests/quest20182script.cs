//--- Melia Script -----------------------------------------------------------
// Historian Rexipher's Research (3)
//--- Description -----------------------------------------------------------
// Quest to Find Historian Rexipher.
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

[QuestScript(20182)]
public class Quest20182Script : QuestScript
{
	protected override void Load()
	{
		SetId(20182);
		SetName("Historian Rexipher's Research (3)");
		SetDescription("Find Historian Rexipher");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS29_MQ4_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(73));
		AddPrerequisite(new CompletedPrerequisite("ROKAS29_MQ2"));
		AddPrerequisite(new ItemPrerequisite("ROKAS29_SLATE2", 1));

		AddObjective("kill0", "Kill 7 Zinutekas(s)", new KillObjective(7, MonsterId.Zinutekas_Q1));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 1387));

		AddDialogHook("ROKAS29_MQ_REXITHER4", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS29_MQ_REXITHER5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS29_MQ4_select01", "ROKAS29_MQ4", "Move to where the next epitaph is located", "I can only help so much"))
		{
			case 1:
				ZoneServer.Instance.World.FindNPC("ROKAS29_MQ_REXITHER4")?.PlayEffectLocal(character.Connection, "F_pc_warp_circle", 1f, "BOT");
				await dialog.Msg("FadeOutIN/1000");
				dialog.HideNPC("ROKAS29_MQ_REXITHER4");
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

		await dialog.Msg("ROKAS29_MQ4_succ01");
		dialog.UnHideNPC("ROKAS29_MQ_REXITHER5");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS29_MQ5");
	}
}

