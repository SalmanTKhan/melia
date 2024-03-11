//--- Melia Script -----------------------------------------------------------
// Source of Magic
//--- Description -----------------------------------------------------------
// Quest to Ask Goddess Lada about the magic.
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

[QuestScript(91042)]
public class Quest91042Script : QuestScript
{
	protected override void Load()
	{
		SetId(91042);
		SetName("Source of Magic");
		SetDescription("Ask Goddess Lada about the magic");

		AddPrerequisite(new LevelPrerequisite(452));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_2_MQ_03"));

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));
		AddReward(new ItemReward("Vis", 28024));

		AddDialogHook("EP13_F_SIAULIAI_2_MQ_LADA_2", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_2_MQ_04_BLACKCRYSTAL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_2_MQ_04_DLG1", "EP13_F_SIAULIAI_2_MQ_04", "I will go to the Morku Farm", "I need some time to rearrange"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/2000");
				dialog.HideNPC("EP13_F_SIAULIAI_2_MQ_LADA_2");
				dialog.UnHideNPC("EP13_F_SIAULIAI_2_MQ_04_SMOKE");
				await dialog.Msg("BalloonText/EP13_F_SIAULIAI_2_MQ_04_DLG3/3");
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

		await dialog.Msg("EP13_F_SIAULIAI_2_MQ_04_DLG4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

