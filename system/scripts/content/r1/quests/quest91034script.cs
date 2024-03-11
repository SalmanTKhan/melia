//--- Melia Script -----------------------------------------------------------
// Goddess' Call
//--- Description -----------------------------------------------------------
// Quest to Meet the Goddess Lada in Laima's Sanctuary{nl}You can move to Laima's Sanctuary by the Goddess Statue in Klaipeda, Orsha, and Fedimian.
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

[QuestScript(91034)]
public class Quest91034Script : QuestScript
{
	protected override void Load()
	{
		SetId(91034);
		SetName("Goddess' Call");
		SetDescription("Meet the Goddess Lada in Laima's Sanctuary{nl}You can move to Laima's Sanctuary by the Goddess Statue in Klaipeda, Orsha, and Fedimian");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_1_MQ_01"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 14));

		AddDialogHook("GODDESS_LADA_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_1_MQ_LADA_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_1_MQ_02_DLG1", "EP13_F_SIAULIAI_1_MQ_02", "I will follow you", "I have other issues to tend to."))
		{
			case 1:
				await dialog.Msg("FadeOutIN/2000");
				dialog.HideNPC("GODDESS_LADA_1");
				dialog.UnHideNPC("EP13_F_SIAULIAI_1_MQ_LADA_1");
				await dialog.Msg("EP13_F_SIAULIAI_1_MQ_02_DLG2");
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

		await dialog.Msg("EP13_F_SIAULIAI_1_MQ_02_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

