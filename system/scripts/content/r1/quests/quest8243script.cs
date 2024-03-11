//--- Melia Script -----------------------------------------------------------
// The Missing Troop (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Danus' Scout.
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

[QuestScript(8243)]
public class Quest8243Script : QuestScript
{
	protected override void Load()
	{
		SetId(8243);
		SetName("The Missing Troop (2)");
		SetDescription("Talk to Danus' Scout");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN14_MQ_02_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(114));
		AddPrerequisite(new CompletedPrerequisite("KATYN14_MQ_01"));

		AddObjective("kill0", "Kill 7 Bite(s)", new KillObjective(7, MonsterId.Honey_Bee));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2736));

		AddDialogHook("KATYN14_VACENIN_CHASE", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN14_VACENIN_CHASE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN14_MQ_02_ST", "KATYN14_MQ_02", "I will kill the monsters first", "I need some time to prepare"))
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

		await dialog.Msg("KATYN14_MQ_02_03");
		await Task.Delay(5000);
		ZoneServer.Instance.World.FindNPC("KATYN14_VACENIN_CHASE")?.PlayEffectLocal(character.Connection, "F_pc_warp_circle", 1f, "BOT");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("KATYN14_VACENIN_CHASE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

