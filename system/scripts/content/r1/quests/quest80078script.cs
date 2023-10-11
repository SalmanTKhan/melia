//--- Melia Script -----------------------------------------------------------
// Great Words (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Dominikas.
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

[QuestScript(80078)]
public class Quest80078Script : QuestScript
{
	protected override void Load()
	{
		SetId(80078);
		SetName("Great Words (1)");
		SetDescription("Talk with Priest Dominikas");

		AddPrerequisite(new LevelPrerequisite(229));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 63));

		AddDialogHook("ABBEY_35_3_DOMINIKAS", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_3_DOMINIKAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY_35_3_SQ_1_start", "ABBEY_35_3_SQ_1", "Nod first", "I'm not interested"))
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

		await dialog.Msg("ABBEY_35_3_SQ_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ABBEY_35_3_SQ_2");
	}
}

