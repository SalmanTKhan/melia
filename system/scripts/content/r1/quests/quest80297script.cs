//--- Melia Script -----------------------------------------------------------
// The Outcome of Choice (5)
//--- Description -----------------------------------------------------------
// Quest to Wait for Ranger Morvio.
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

[QuestScript(80297)]
public class Quest80297Script : QuestScript
{
	protected override void Load()
	{
		SetId(80297);
		SetName("The Outcome of Choice (5)");
		SetDescription("Wait for Ranger Morvio");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "F_3CMLAKE_87_MQ_13_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(370));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_87_MQ_12"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("F_3CMLAKE_87_MQ_13_TRRIGER", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_87_MQ_13_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("F_3CMLAKE_87_MQ_13_SU");
		await dialog.Msg("FadeOutIN/2000");
		dialog.HideNPC("F_3CMLAKE_87_MQ_13_NPC");
		dialog.UnHideNPC("F_3CMLAKE_87_MQ_01_NPC_1");
		// Func/SCR_F_3CMLAKE_87_MQ_13_NPC_AFTER;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.HideNPC("F_3CMLAKE_87_MQ_01_NPC_1");
		dialog.HideNPC("F_3CMLAKE_87_MQ_01_NPC_2");
		dialog.HideNPC("F_3CMLAKE_87_MQ_01_NPC_3");
		dialog.HideNPC("F_3CMLAKE_87_MQ_10_NPC_1");
		dialog.UnHideNPC("F_3CMLAKE_87_MQ_05_NPC");
		dialog.UnHideNPC("F_3CMLAKE_87_MQ_13_NPC");
	}
}

