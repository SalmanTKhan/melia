//--- Melia Script -----------------------------------------------------------
// Preparations (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Resistance Soldier Mait.
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

[QuestScript(80240)]
public class Quest80240Script : QuestScript
{
	protected override void Load()
	{
		SetId(80240);
		SetName("Preparations (1)");
		SetDescription("Talk to the Resistance Soldier Mait");

		AddPrerequisite(new LevelPrerequisite(362));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("F_3CMLAKE_85_MQ_01_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_85_MQ_02_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_85_MQ_01_ST", "F_3CMLAKE_85_MQ_01", "I'm a Revelator.", "Oh, I'm just passing by."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_85_MQ_01_AFST");
				dialog.HideNPC("F_3CMLAKE_85_MQ_01_NPC_1");
				await dialog.Msg("FadeOutIN/1000");
				// Func/F_3CMLAKE_85_MQ_01_RUN;
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

		await dialog.Msg("F_3CMLAKE_85_MQ_01_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

