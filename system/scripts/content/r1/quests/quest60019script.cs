//--- Melia Script -----------------------------------------------------------
// Hauberk in the Maze (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Daiva.
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

[QuestScript(60019)]
public class Quest60019Script : QuestScript
{
	protected override void Load()
	{
		SetId(60019);
		SetName("Hauberk in the Maze (2)");
		SetDescription("Talk to Kupole Daiva");

		AddPrerequisite(new LevelPrerequisite(160));
		AddPrerequisite(new CompletedPrerequisite("VPRISON513_MQ_01"));

		AddObjective("collect0", "Collect 10 Hauberk's Soul Fragment(s)", new CollectItemObjective("VPRISON513_MQ_02_ITEM", 10));
		AddDrop("VPRISON513_MQ_02_ITEM", 7f, 57716, 57717, 57719, 57715);

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));
		AddReward(new ItemReward("Vis", 4800));

		AddDialogHook("VPRISON513_MQ_DAIVA_01", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON513_MQ_DAIVA_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON513_MQ_02_01", "VPRISON513_MQ_02", "Yeah, I'll collect them", "It doesn't sound like a good idea"))
		{
			case 1:
				await dialog.Msg("VPRISON513_MQ_02_AG");
				dialog.HideNPC("VPRISON513_MQ_DAIVA_01");
				await dialog.Msg("FadeOutIN/1500");
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

		if (character.Inventory.HasItem("VPRISON513_MQ_02_ITEM", 10))
		{
			character.Inventory.RemoveItem("VPRISON513_MQ_02_ITEM", 10);
			await dialog.Msg("VPRISON513_MQ_02_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

