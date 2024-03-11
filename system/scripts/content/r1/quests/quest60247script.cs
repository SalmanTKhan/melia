//--- Melia Script -----------------------------------------------------------
// Trapped Destiny (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Rugile.
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

[QuestScript(60247)]
public class Quest60247Script : QuestScript
{
	protected override void Load()
	{
		SetId(60247);
		SetName("Trapped Destiny (4)");
		SetDescription("Talk to Kupole Rugile");

		AddPrerequisite(new LevelPrerequisite(335));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB481_MQ_5"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));

		AddDialogHook("FLIBRARY481_RUGILE_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY481_NERINGA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB481_MQ_6_1", "FANTASYLIB481_MQ_6", "I'll think it through", "I refuse."))
		{
			case 1:
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

		await dialog.Msg("FANTASYLIB481_MQ_6_3");
		dialog.HideNPC("FLIBRARY481_NERINGA_NPC");
		await dialog.Msg("FadeOutIN/2000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

