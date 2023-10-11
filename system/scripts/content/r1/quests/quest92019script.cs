//--- Melia Script -----------------------------------------------------------
// In Search of Means
//--- Description -----------------------------------------------------------
// Quest to Speak with Goddess Lada.
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

[QuestScript(92019)]
public class Quest92019Script : QuestScript
{
	protected override void Load()
	{
		SetId(92019);
		SetName("In Search of Means");
		SetDescription("Speak with Goddess Lada");

		AddPrerequisite(new LevelPrerequisite(456));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_4_MQ_01"));

		AddReward(new ItemReward("EP13_F_SIAULIAI_4_MQ_02_ITEM", 1));
		AddReward(new ItemReward("EP13_F_SIAULIAI_4_MQ_02_ITEM2", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 33));

		AddDialogHook("EP13_GODDESS_LADA4TO5", "BeforeStart", BeforeStart);
		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_4_MQ_02_DLG1", "EP13_F_SIAULIAI_4_MQ_02", "I have someone comes to mind", "I'm not sure"))
		{
			case 1:
				await dialog.Msg("EP13_F_SIAULIAI_4_MQ_02_DLG2");
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

		await dialog.Msg("EP13_F_SIAULIAI_4_MQ_02_DLG3");
		await dialog.Msg("EP13_F_SIAULIAI_4_MQ_02_DLG4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

