//--- Melia Script -----------------------------------------------------------
// Covert Operation (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Resistance Adjutant Taylor.
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

[QuestScript(80261)]
public class Quest80261Script : QuestScript
{
	protected override void Load()
	{
		SetId(80261);
		SetName("Covert Operation (2)");
		SetDescription("Talk to the Resistance Adjutant Taylor");

		AddPrerequisite(new LevelPrerequisite(366));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_01"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19032));

		AddDialogHook("F_3CMLAKE_86_MQ_02_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_86_MQ_03_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_86_MQ_02_ST", "F_3CMLAKE_86_MQ_02", "Leave it to me.", "Sounds like too much trouble."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_86_MQ_02_AFST");
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

		await dialog.Msg("F_3CMLAKE_86_MQ_02_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

