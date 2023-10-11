//--- Melia Script -----------------------------------------------------------
// The First Guest's Role (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(60240)]
public class Quest60240Script : QuestScript
{
	protected override void Load()
	{
		SetId(60240);
		SetName("The First Guest's Role (1)");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new LevelPrerequisite(335));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("WTREE212_NERINGA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("WTREE212_NERINGA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB481_MQ_PRE_1_1", "FANTASYLIB481_MQ_PRE_1", "I'm listening.", "Skip the explanation"))
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

		await dialog.Msg("FANTASYLIB481_MQ_PRE_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

