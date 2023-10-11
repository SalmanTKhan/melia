//--- Melia Script -----------------------------------------------------------
// Enemy Ambush (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Resistance Adjutant Taylor.
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

[QuestScript(80266)]
public class Quest80266Script : QuestScript
{
	protected override void Load()
	{
		SetId(80266);
		SetName("Enemy Ambush (3)");
		SetDescription("Talk to the Resistance Adjutant Taylor");

		AddPrerequisite(new LevelPrerequisite(366));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_06"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("F_3CMLAKE_86_MQ_07_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_86_MQ_01_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_86_MQ_07_ST", "F_3CMLAKE_86_MQ_07", "Let's get a move on.", "I'm not interested."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_86_MQ_07_AFST");
				dialog.HideNPC("F_3CMLAKE_86_MQ_07_NPC");
				dialog.UnHideNPC("F_3CMLAKE_86_MQ_02_NPC");
				await dialog.Msg("FadeOutIN/2000");
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

		await dialog.Msg("F_3CMLAKE_86_MQ_07_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

