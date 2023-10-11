//--- Melia Script -----------------------------------------------------------
// A Powerful Arrow (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Elder Ramunas.
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

[QuestScript(80287)]
public class Quest80287Script : QuestScript
{
	protected override void Load()
	{
		SetId(80287);
		SetName("A Powerful Arrow (1)");
		SetDescription("Talk to Elder Ramunas");

		AddPrerequisite(new LevelPrerequisite(370));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_87_MQ_02"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("F_3CMLAKE_87_MQ_03_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FLETCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_87_MQ_03_ST", "F_3CMLAKE_87_MQ_03", "I'll be right back.", "About the Essence of Ziburynas.", "It's too far away."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_87_MQ_03_AFST");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("F_3CMLAKE_87_MQ_03_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("F_3CMLAKE_87_MQ_03_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

