//--- Melia Script -----------------------------------------------------------
// Trapped Destiny (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(60244)]
public class Quest60244Script : QuestScript
{
	protected override void Load()
	{
		SetId(60244);
		SetName("Trapped Destiny (1)");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new LevelPrerequisite(335));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB481_MQ_1"), new CompletedPrerequisite("FANTASYLIB481_MQ_2"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("FLIBRARY481_NERINGA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY481_RUGILE_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB481_MQ_3_1", "FANTASYLIB481_MQ_3", "I'll go there", "I need little more time"))
		{
			case 1:
				dialog.UnHideNPC("FANTASYLIB481_MQ_3_NPC");
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

		await dialog.Msg("FANTASYLIB481_MQ_3_3");
		dialog.HideNPC("FANTASYLIB481_MQ_3_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

