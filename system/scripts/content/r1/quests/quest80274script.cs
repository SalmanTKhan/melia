//--- Melia Script -----------------------------------------------------------
// Lydia Schaffen's Relic (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Adjutant Lehon.
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

[QuestScript(80274)]
public class Quest80274Script : QuestScript
{
	protected override void Load()
	{
		SetId(80274);
		SetName("Lydia Schaffen's Relic (7)");
		SetDescription("Talk to Resistance Adjutant Lehon");

		AddPrerequisite(new LevelPrerequisite(366));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_14"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("F_3CMLAKE_86_MQ_15_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_86_MQ_16_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_86_MQ_15_ST", "F_3CMLAKE_86_MQ_15", "Don't worry.", "I can't leave you behind."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_86_MQ_15_AFST");
				dialog.UnHideNPC("F_3CMLAKE_86_MQ_16_NPC");
				dialog.HideNPC("F_3CMLAKE_86_MQ_18_NPC");
				dialog.HideNPC("F_3CMLAKE_86_MQ_18_NPC_3");
				dialog.UnHideNPC("F_3CMLAKE_86_WOODENWALL_DESTROY");
				dialog.HideNPC("F_3CMLAKE_86_WOODENWALL");
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

		await dialog.Msg("F_3CMLAKE_86_MQ_15_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

