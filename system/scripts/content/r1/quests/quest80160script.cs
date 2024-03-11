//--- Melia Script -----------------------------------------------------------
// Evil Talismans
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Serija.
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

[QuestScript(80160)]
public class Quest80160Script : QuestScript
{
	protected override void Load()
	{
		SetId(80160);
		SetName("Evil Talismans");
		SetDescription("Talk to Kupole Serija");

		AddPrerequisite(new LevelPrerequisite(298));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_5_MQ_10"));

		AddObjective("collect0", "Collect 15 Evil Talismans(s)", new CollectItemObjective("LIMESTONE_52_4_MQ_3_CHARM2", 15));
		AddDrop("LIMESTONE_52_4_MQ_3_CHARM2", 10f, 58472, 58473);

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12516));

		AddDialogHook("LIMESTONECAVE_52_4_SERIJA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_4_SERIJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_4_SQ_2_start", "LIMESTONE_52_4_SQ_2", "Yeah, I'll collect them", "No way that's going to happen."))
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

		if (character.Inventory.HasItem("LIMESTONE_52_4_MQ_3_CHARM2", 15))
		{
			character.Inventory.RemoveItem("LIMESTONE_52_4_MQ_3_CHARM2", 15);
			await dialog.Msg("LIMESTONE_52_4_SQ_2_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

