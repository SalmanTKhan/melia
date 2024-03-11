//--- Melia Script -----------------------------------------------------------
// Preparations (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Adjutant Bern.
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

[QuestScript(80241)]
public class Quest80241Script : QuestScript
{
	protected override void Load()
	{
		SetId(80241);
		SetName("Preparations (2)");
		SetDescription("Talk to Resistance Adjutant Bern");

		AddPrerequisite(new LevelPrerequisite(362));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_85_MQ_01"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("F_3CMLAKE_85_MQ_02_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_85_MQ_02_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_85_MQ_02_ST", "F_3CMLAKE_85_MQ_02", "I will help", "About the Resistance", "That sounds difficult."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_85_MQ_02_AFST");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("F_3CMLAKE_85_MQ_02_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("F_3CMLAKE_85_MQ_02_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

