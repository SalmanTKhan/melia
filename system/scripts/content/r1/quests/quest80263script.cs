//--- Melia Script -----------------------------------------------------------
// Covert Operation (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Adjutant Lehon.
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

[QuestScript(80263)]
public class Quest80263Script : QuestScript
{
	protected override void Load()
	{
		SetId(80263);
		SetName("Covert Operation (4)");
		SetDescription("Talk to Resistance Adjutant Lehon");

		AddPrerequisite(new LevelPrerequisite(366));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_03"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19032));

		AddDialogHook("F_3CMLAKE_86_MQ_03_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_86_MQ_03_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_86_MQ_04_ST", "F_3CMLAKE_86_MQ_04", "I'll give it a shot.", "I'm afraid."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_86_MQ_04_AFST");
				await dialog.Msg("FadeOutIN/1000");
				// Func/SCR_F_3CMLAKE_86_MQ_04_START;
				character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "You've disguised yourself as an enemy!{nl}Poison the enemy supplies as requested!", 5);
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

		await dialog.Msg("F_3CMLAKE_86_MQ_04_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

