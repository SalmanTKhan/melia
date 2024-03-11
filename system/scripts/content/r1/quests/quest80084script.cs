//--- Melia Script -----------------------------------------------------------
// Dirty Tricks (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Dominikas.
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

[QuestScript(80084)]
public class Quest80084Script : QuestScript
{
	protected override void Load()
	{
		SetId(80084);
		SetName("Dirty Tricks (2)");
		SetDescription("Talk with Priest Dominikas");

		AddPrerequisite(new LevelPrerequisite(229));
		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_3_SQ_6"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 63));

		AddDialogHook("ABBEY_35_3_DOMINIKAS_2", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_3_DOMINIKAS_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY_35_3_SQ_7_start", "ABBEY_35_3_SQ_7", "Alright", "I will think about it"))
		{
			case 1:
				// Func/ABBEY_35_3_SQ_7_START;
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


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ABBEY_35_3_SQ_8");
	}
}

