//--- Melia Script -----------------------------------------------------------
// A Thankful Heart
//--- Description -----------------------------------------------------------
// Quest to Talk with Settler Izna.
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

[QuestScript(60077)]
public class Quest60077Script : QuestScript
{
	protected override void Load()
	{
		SetId(60077);
		SetName("A Thankful Heart");
		SetDescription("Talk with Settler Izna");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 4 Red Leaf(s)", new CollectItemObjective("SIAU16_SQ_01_ITEM", 4));
		AddDrop("SIAU16_SQ_01_ITEM", 10f, "Sec_Leaf_diving");

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("expCard1", 2));
		AddReward(new ItemReward("Vis", 13));
		AddReward(new ItemReward("Drug_HP1_Q", 3));

		AddDialogHook("SIAULIAI16_IZNA", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI16_IZNA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU16_SQ_01_01", "SIAU16_SQ_01", "Yeah, I'll collect them", "I don't need it"))
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

