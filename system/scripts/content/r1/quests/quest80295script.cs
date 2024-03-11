//--- Melia Script -----------------------------------------------------------
// The Outcome of Choice (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Ranger Morvio.
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

[QuestScript(80295)]
public class Quest80295Script : QuestScript
{
	protected override void Load()
	{
		SetId(80295);
		SetName("The Outcome of Choice (3)");
		SetDescription("Talk to Ranger Morvio");

		AddPrerequisite(new LevelPrerequisite(370));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_87_MQ_10"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19240));

		AddDialogHook("F_3CMLAKE_87_MQ_10_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_87_MQ_12_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_87_MQ_11_ST", "F_3CMLAKE_87_MQ_11", "Let's go after him.", "There's no time for that now."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_87_MQ_11_AFST");
				dialog.HideNPC("F_3CMLAKE_87_MQ_10_NPC_2");
				// Func/SCR_F_3CMLAKE_87_MQ_11_RUNNPC;
				dialog.UnHideNPC("F_3CMLAKE_87_MQ_11_OBJ_1");
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

		await dialog.Msg("F_3CMLAKE_87_MQ_11_SU");
		dialog.UnHideNPC("F_3CMLAKE_87_MQ_12_NPC");
		dialog.HideNPC("F_3CMLAKE_87_FOLLOWER1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

