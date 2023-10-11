//--- Melia Script -----------------------------------------------------------
// Wrong Faith (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Villager Nella.
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

[QuestScript(80080)]
public class Quest80080Script : QuestScript
{
	protected override void Load()
	{
		SetId(80080);
		SetName("Wrong Faith (1)");
		SetDescription("Talk with Villager Nella");

		AddPrerequisite(new LevelPrerequisite(229));
		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_3_SQ_2"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 63));
		AddReward(new ItemReward("Vis", 8244));

		AddDialogHook("ABBEY_35_3_VILLAGE_A_2", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_3_VILLAGE_A_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY_35_3_SQ_3_start", "ABBEY_35_3_SQ_3", "I will collect them", "I can't believe it"))
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

		await dialog.Msg("ABBEY_35_3_SQ_3_succ");
		// Func/ABBEY_35_3_SQ_3_COMP;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

