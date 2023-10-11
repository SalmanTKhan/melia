//--- Melia Script -----------------------------------------------------------
// For an Assured Victory (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Ranger Morvio.
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

[QuestScript(80286)]
public class Quest80286Script : QuestScript
{
	protected override void Load()
	{
		SetId(80286);
		SetName("For an Assured Victory (2)");
		SetDescription("Talk to Ranger Morvio");

		AddPrerequisite(new LevelPrerequisite(370));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_87_MQ_01"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19240));

		AddDialogHook("F_3CMLAKE_87_MQ_01_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_87_MQ_01_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_87_MQ_02_ST", "F_3CMLAKE_87_MQ_02", "Leave it to me.", "About the people helping the Resistance.", "That sounds difficult."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_87_MQ_02_AFST");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("F_3CMLAKE_87_MQ_02_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("F_3CMLAKE_87_MQ_02_SU");
		dialog.UnHideNPC("F_3CMLAKE_87_MQ_03_NPC");
		dialog.HideNPC("F_3CMLAKE_86_MQ_01_NPC_2");
		await dialog.Msg("FadeOutIN/1000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

