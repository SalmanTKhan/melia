//--- Melia Script -----------------------------------------------------------
// Necessary Mistake (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Litae.
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

[QuestScript(60257)]
public class Quest60257Script : QuestScript
{
	protected override void Load()
	{
		SetId(60257);
		SetName("Necessary Mistake (3)");
		SetDescription("Talk to Kupole Litae");

		AddPrerequisite(new LevelPrerequisite(341));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB483_MQ_2"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));

		AddDialogHook("FLIBRARY483_RYTE_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY483_RYTE_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB483_MQ_3_1", "FANTASYLIB483_MQ_3", "I'll activate it.", "I need to prepare"))
		{
			case 1:
				dialog.UnHideNPC("FANTASYLIB483_MQ_3_NPC");
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

		await dialog.Msg("FANTASYLIB483_MQ_3_3");
		dialog.HideNPC("FANTASYLIB483_MQ_3_NPC");
		await dialog.Msg("FadeOutIN/1500");
		dialog.HideNPC("FLIBRARY483_RYTE_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

