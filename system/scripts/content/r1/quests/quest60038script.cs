//--- Melia Script -----------------------------------------------------------
// Demons at the Crossroads
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Daiva.
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

[QuestScript(60038)]
public class Quest60038Script : QuestScript
{
	protected override void Load()
	{
		SetId(60038);
		SetName("Demons at the Crossroads");
		SetDescription("Talk to Kupole Daiva");

		AddPrerequisite(new LevelPrerequisite(160));
		AddPrerequisite(new CompletedPrerequisite("VPRISON513_SQ_01"));

		AddObjective("collect0", "Collect 8 Demon Teeth(s)", new CollectItemObjective("VPRISON513_SQ_03_ITEM", 8));
		AddDrop("VPRISON513_SQ_03_ITEM", 10f, 57716, 57717, 57719, 57715);

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 4800));

		AddDialogHook("VPRISON513_MQ_DAIVA_03", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON513_MQ_DAIVA_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON513_SQ_03_01", "VPRISON513_SQ_03", "I'll bring it ", "I might be scolded by the goddess"))
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

		if (character.Inventory.HasItem("VPRISON513_SQ_03_ITEM", 8))
		{
			character.Inventory.RemoveItem("VPRISON513_SQ_03_ITEM", 8);
			await dialog.Msg("VPRISON513_SQ_03_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

