//--- Melia Script -----------------------------------------------------------
// The Evening Star Key (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Zydrone.
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

[QuestScript(60013)]
public class Quest60013Script : QuestScript
{
	protected override void Load()
	{
		SetId(60013);
		SetName("The Evening Star Key (1)");
		SetDescription("Talk to Kupole Zydrone");

		AddPrerequisite(new LevelPrerequisite(157));
		AddPrerequisite(new CompletedPrerequisite("VPRISON514_MQ_01"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));
		AddReward(new ItemReward("Vis", 4553));

		AddDialogHook("VPRISON514_MQ_ZYDRONE", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON514_MQ_ZYDRONE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON514_MQ_02_01", "VPRISON514_MQ_02", "I will help you to make the keys", "I need to prepare"))
		{
			case 1:
				await dialog.Msg("VPRISON514_MQ_02_AG");
				dialog.UnHideNPC("VPRISON514_MQ_02_NPC_01");
				dialog.UnHideNPC("VPRISON514_MQ_02_NPC_02");
				dialog.UnHideNPC("VPRISON514_MQ_02_NPC_03");
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

		await dialog.Msg("VPRISON514_MQ_02_03");
		dialog.HideNPC("VPRISON514_MQ_02_NPC_01");
		dialog.HideNPC("VPRISON514_MQ_02_NPC_02");
		dialog.HideNPC("VPRISON514_MQ_02_NPC_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

