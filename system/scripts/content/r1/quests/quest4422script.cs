//--- Melia Script -----------------------------------------------------------
// Missing Researcher (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Assistant Airine.
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

[QuestScript(4422)]
public class Quest4422Script : QuestScript
{
	protected override void Load()
	{
		SetId(4422);
		SetName("Missing Researcher (5)");
		SetDescription("Talk to Assistant Airine");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS27_QB_10_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(67));
		AddPrerequisite(new CompletedPrerequisite("ROKAS27_QB_8"));

		AddObjective("kill0", "Kill 1 Scorpio", new KillObjective(1, MonsterId.Boss_Confinedion));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("misc_Confinedion", 1));
		AddReward(new ItemReward("Vis", 1273));

		AddDialogHook("ROKAS27_AIRINE", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS27_AIRINE2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS27_QB_10_select1", "ROKAS27_QB_10", "Say goodbye", "Tell her that it would be better to take some rest here"))
		{
			case 1:
				dialog.HideNPC("ROKAS27_DESIG_02");
				dialog.UnHideNPC("ROKAS27_DESIG_03");
				ZoneServer.Instance.World.FindNPC("ROKAS27_AIRINE")?.PlayEffectLocal(character.Connection, "F_pc_warp_circle", 1f, "BOT");
				await dialog.Msg("FadeOutIN/1000");
				dialog.HideNPC("ROKAS27_AIRINE");
				dialog.UnHideNPC("ROKAS27_AIRINE2");
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

		await dialog.Msg("ROKAS27_QB_10_succ1");
		dialog.HideNPC("ROKAS27_AIRINE_EFFECT");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS27_QB_11");
	}
}

