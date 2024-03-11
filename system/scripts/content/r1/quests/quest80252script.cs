//--- Melia Script -----------------------------------------------------------
// Kron's Trust
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Deputy Commander Kron.
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

[QuestScript(80252)]
public class Quest80252Script : QuestScript
{
	protected override void Load()
	{
		SetId(80252);
		SetName("Kron's Trust");
		SetDescription("Talk to Resistance Deputy Commander Kron");

		AddPrerequisite(new LevelPrerequisite(362));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_85_MQ_09"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("F_3CMLAKE_85_MQ_03_ITEM_01", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("F_3CMLAKE_85_MQ_10_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_85_MQ_03_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_85_MQ_10_ST", "F_3CMLAKE_85_MQ_10", "We should get a move on.", "Give me a moment to rest."))
		{
			case 1:
				dialog.HideNPC("F_3CMLAKE_85_MQ_10_NPC");
				await dialog.Msg("FadeOutIN/1000");
				dialog.UnHideNPC("F_3CMLAKE_85_MQ_03_NPC");
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

		await dialog.Msg("F_3CMLAKE_85_MQ_10_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

