//--- Melia Script -----------------------------------------------------------
// Lydia Schaffen's Relic (10)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Commander Byle.
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

[QuestScript(80277)]
public class Quest80277Script : QuestScript
{
	protected override void Load()
	{
		SetId(80277);
		SetName("Lydia Schaffen's Relic (10)");
		SetDescription("Talk to Resistance Commander Byle");

		AddPrerequisite(new LevelPrerequisite(366));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_17"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("F_3CMLAKE_86_MQ_18_NPC", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_86_MQ_18_ST", "F_3CMLAKE_86_MQ_18", "Alright", "I'll think about it."))
		{
			case 1:
				dialog.UnHideNPC("F_3CMLAKE_87_MQ_01_NPC_2");
				dialog.UnHideNPC("F_3CMLAKE_87_MQ_01_NPC_3");
				dialog.HideNPC("F_3CMLAKE_86_MQ_18_NPC");
				dialog.HideNPC("F_3CMLAKE_86_MQ_18_NPC_2");
				await dialog.Msg("FadeOutIN/1000");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

