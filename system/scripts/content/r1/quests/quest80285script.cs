//--- Melia Script -----------------------------------------------------------
// For an Assured Victory (1)
//--- Description -----------------------------------------------------------
// Quest to Go to Barynwell 87 Waters.
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

[QuestScript(80285)]
public class Quest80285Script : QuestScript
{
	protected override void Load()
	{
		SetId(80285);
		SetName("For an Assured Victory (1)");
		SetDescription("Go to Barynwell 87 Waters");

		AddPrerequisite(new LevelPrerequisite(370));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_18"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("F_3CMLAKE_87_MQ_01_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_87_MQ_01_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_87_MQ_01_ST", "F_3CMLAKE_87_MQ_01", "I'll try.", "That's not something I want to do."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_87_MQ_01_AFST");
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

		await dialog.Msg("F_3CMLAKE_87_MQ_01_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

