//--- Melia Script -----------------------------------------------------------
// Fight Poison With Poison
//--- Description -----------------------------------------------------------
// Quest to Talk with Chaser Torvana.
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

[QuestScript(60123)]
public class Quest60123Script : QuestScript
{
	protected override void Load()
	{
		SetId(60123);
		SetName("Fight Poison With Poison");
		SetDescription("Talk with Chaser Torvana");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 7 Black Wooden Piece(s)", new CollectItemObjective("PRISON621_SQ_02_ITEM", 7));
		AddDrop("PRISON621_SQ_02_ITEM", 7f, 57991, 58002, 58094, 11127);

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 221));

		AddDialogHook("PRISON621_TORNAVA", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON621_TORNAVA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON621_SQ_02_01", "PRISON621_SQ_02", "I'm not sure, but I'll gather some", "That's absurd"))
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


		return HookResult.Break;
	}
}

