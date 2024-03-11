//--- Melia Script -----------------------------------------------------------
// Extra Extra Careful 
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Oort.
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

[QuestScript(80292)]
public class Quest80292Script : QuestScript
{
	protected override void Load()
	{
		SetId(80292);
		SetName("Extra Extra Careful ");
		SetDescription("Talk to Hunter Oort");

		AddPrerequisite(new LevelPrerequisite(370));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_87_MQ_05"), new CompletedPrerequisite("F_3CMLAKE_87_MQ_06"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 38480));

		AddDialogHook("F_3CMLAKE_87_MQ_07_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_87_MQ_09_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_87_MQ_08_ST", "F_3CMLAKE_87_MQ_08", "Alright", "Give me some time."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_87_MQ_08_AFST");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Talk to Ranger Morvio and Fletcher and move!");
				// Func/TX_F_3CMLAKE_87_MQ_05_NPC_RUN;
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

		await dialog.Msg("F_3CMLAKE_87_MQ_08_SU");
		dialog.UnHideNPC("F_3CMLAKE_87_MQ_09_NPC_1");
		dialog.UnHideNPC("F_3CMLAKE_87_MQ_09_NPC_2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

