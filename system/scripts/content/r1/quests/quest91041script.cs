//--- Melia Script -----------------------------------------------------------
// Investigate Crevice
//--- Description -----------------------------------------------------------
// Quest to Talk to the Goddess Lada.
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

[QuestScript(91041)]
public class Quest91041Script : QuestScript
{
	protected override void Load()
	{
		SetId(91041);
		SetName("Investigate Crevice");
		SetDescription("Talk to the Goddess Lada");

		AddPrerequisite(new LevelPrerequisite(452));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_2_MQ_02"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));
		AddReward(new ItemReward("Vis", 28024));

		AddDialogHook("EP13_F_SIAULIAI_2_MQ_LADA_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_2_MQ_LADA_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_2_MQ_03_DLG1", "EP13_F_SIAULIAI_2_MQ_03", "I was about to go to Gyvenimo Crossroads", "I will handle other place's work first"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/2000");
				dialog.HideNPC("EP13_F_SIAULIAI_2_MQ_LADA_1");
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

		await dialog.Msg("EP13_F_SIAULIAI_2_MQ_03_DLG2");
		dialog.UnHideNPC("EP13_F_SIAULIAI_2_MQ_LADA_2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

