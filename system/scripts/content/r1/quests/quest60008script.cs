//--- Melia Script -----------------------------------------------------------
// Ridding the Traitor (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Arune.
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

[QuestScript(60008)]
public class Quest60008Script : QuestScript
{
	protected override void Load()
	{
		SetId(60008);
		SetName("Ridding the Traitor (2)");
		SetDescription("Talk to Kupole Arune");

		AddPrerequisite(new LevelPrerequisite(154));
		AddPrerequisite(new CompletedPrerequisite("VPRISON512_MQ_01"));

		AddObjective("collect0", "Collect 7 Hauberk's Mark(s)", new CollectItemObjective("VPRISON512_MQ_02_ITEM", 7));
		AddDrop("VPRISON512_MQ_02_ITEM", 10f, 57692, 57690, 57688);

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));
		AddReward(new ItemReward("Vis", 4466));

		AddDialogHook("VPRISON512_MQ_NORGAILE", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON512_MQ_NORGAILE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON512_MQ_02_01", "VPRISON512_MQ_02", "What should I do?", "That sounds dangerous"))
		{
			case 1:
				await dialog.Msg("VPRISON512_MQ_02_AG");
				// Func/VPRISON512_MQ_02_HAUBERK_01;
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

		if (character.Inventory.HasItem("VPRISON512_MQ_02_ITEM", 7))
		{
			character.Inventory.RemoveItem("VPRISON512_MQ_02_ITEM", 7);
			await dialog.Msg("VPRISON512_MQ_02_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

