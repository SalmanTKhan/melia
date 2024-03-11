//--- Melia Script -----------------------------------------------------------
// Monster Gone Wild (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Pyromancer Master.
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

[QuestScript(50009)]
public class Quest50009Script : QuestScript
{
	protected override void Load()
	{
		SetId(50009);
		SetName("Monster Gone Wild (1)");
		SetDescription("Talk to the Pyromancer Master");

		AddPrerequisite(new LevelPrerequisite(69));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_50_1_SQ_010"));

		AddObjective("collect0", "Collect 10 Pink Chupaluka Heart(s)", new CollectItemObjective("SIAULIAI50_MON_SAMPLE", 10));
		AddDrop("SIAULIAI50_MON_SAMPLE", 7.5f, "Chupaluka_pink");

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1311));

		AddDialogHook("MASTER_FIREMAGE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FIREMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_50_1_SQ_020_select01", "SIAULIAI_50_1_SQ_020", "Ask her what to do next", "Decline"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_50_1_SQ_020_selectnpc01");
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

		if (character.Inventory.HasItem("SIAULIAI50_MON_SAMPLE", 10))
		{
			character.Inventory.RemoveItem("SIAULIAI50_MON_SAMPLE", 10);
			await dialog.Msg("SIAULIAI_50_1_SQ_020_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_50_1_SQ_030");
	}
}

