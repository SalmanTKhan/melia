//--- Melia Script -----------------------------------------------------------
// Historian Rexipher's Research (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Historian Rexipher.
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

[QuestScript(20179)]
public class Quest20179Script : QuestScript
{
	protected override void Load()
	{
		SetId(20179);
		SetName("Historian Rexipher's Research (1)");
		SetDescription("Talk to Historian Rexipher");

		AddPrerequisite(new LevelPrerequisite(73));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Drug_SP2_Q", 20));
		AddReward(new ItemReward("Vis", 1387));

		AddDialogHook("ROKAS29_MQ_REXITHER1", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS29_MQ_REXITHER2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS29_MQ1_select", "ROKAS29_MQ1", "I will cooperate", "I don't need it"))
		{
			case 1:
				await dialog.Msg("ROKAS29_MQ1_select_Q");
				ZoneServer.Instance.World.FindNPC("ROKAS29_MQ_REXITHER1")?.PlayEffectLocal(character.Connection, "F_pc_warp_circle", 1f, "BOT");
				dialog.HideNPC("ROKAS29_MQ_REXITHER1");
				await dialog.Msg("FadeOutIN/2000");
				dialog.UnHideNPC("ROKAS29_MQ_REXITHER2");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await Task.Delay(1000);
		await Task.Delay(500);
		await dialog.Msg("BalloonText/ROKAS29_MQ2_succ02/3");
		await Task.Delay(3000);
		await dialog.Msg("ROKAS29_MQ1_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS29_MQ2");
	}
}

