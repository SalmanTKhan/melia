//--- Melia Script -----------------------------------------------------------
// Mirtinas' Whereabouts (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Lada.
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

[QuestScript(91052)]
public class Quest91052Script : QuestScript
{
	protected override void Load()
	{
		SetId(91052);
		SetName("Mirtinas' Whereabouts (1)");
		SetDescription("Talk to Goddess Lada");

		AddPrerequisite(new LevelPrerequisite(454));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_3_MQ_05"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));
		AddReward(new ItemReward("Vis", 28148));

		AddDialogHook("EP13_F_SIAULIAI_3_MQ_LADA_3", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_3_MQ_LADA_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_3_MQ_06_DLG1", "EP13_F_SIAULIAI_3_MQ_06", "Meanwhile, I'll investigate the Mirtinas crevice nearby", "There is other thing to do, so take a rest"))
		{
			case 1:
				await dialog.Msg("EP13_F_SIAULIAI_3_MQ_06_DLG2");
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

		await dialog.Msg("EP13_F_SIAULIAI_3_MQ_06_DLG4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

