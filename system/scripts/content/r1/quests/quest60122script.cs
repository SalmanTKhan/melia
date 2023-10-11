//--- Melia Script -----------------------------------------------------------
// Blackmail
//--- Description -----------------------------------------------------------
// Quest to Talk with Chaser Torvana.
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

[QuestScript(60122)]
public class Quest60122Script : QuestScript
{
	protected override void Load()
	{
		SetId(60122);
		SetName("Blackmail");
		SetDescription("Talk with Chaser Torvana");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 7 Red Essence(s)", new CollectItemObjective("PRISON621_SQ_01_ITEM", 7));
		AddDrop("PRISON621_SQ_01_ITEM", 6f, 57991, 58002);

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Drug_SP1_Q", 25));
		AddReward(new ItemReward("Vis", 221));

		AddDialogHook("PRISON621_TORNAVA", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON621_TORNAVA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON621_SQ_01_01", "PRISON621_SQ_01", "Yeah, I'll collect them", "I don't think I can be of help"))
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

