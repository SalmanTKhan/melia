//--- Melia Script -----------------------------------------------------------
// Initiate the Investigation (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Goddess Lada.
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

[QuestScript(91037)]
public class Quest91037Script : QuestScript
{
	protected override void Load()
	{
		SetId(91037);
		SetName("Initiate the Investigation (3)");
		SetDescription("Talk to the Goddess Lada");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_1_MQ_04"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("EP13_F_SIAULIAI_1_MQ_LADA_2", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_1_MQ_LADA_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_1_MQ_05_DLG1", "EP13_F_SIAULIAI_1_MQ_05", "I will be headed to the Adata Highway", "I will come after doing something else"))
		{
			case 1:
				// Func/SCR_EP13_F_SIAULIAI_1_MQ_LADA_2_HIDE;
				dialog.UnHideNPC("EP13_F_SIAULIAI_1_MQ_LADA_3");
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

		await dialog.Msg("EP13_F_SIAULIAI_1_MQ_05_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

