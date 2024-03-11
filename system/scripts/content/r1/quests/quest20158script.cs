//--- Melia Script -----------------------------------------------------------
// Mop Up the Forger (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kevin.
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

[QuestScript(20158)]
public class Quest20158Script : QuestScript
{
	protected override void Load()
	{
		SetId(20158);
		SetName("Mop Up the Forger (2)");
		SetDescription("Talk to Kevin");

		AddPrerequisite(new LevelPrerequisite(61));
		AddPrerequisite(new CompletedPrerequisite("ROKAS25_SQ_01"));

		AddObjective("collect0", "Collect 8 Hard Lime(s)", new CollectItemObjective("ROKAS25_FOOD", 8));
		AddDrop("ROKAS25_FOOD", 10f, 47329, 47327, 57039);

		AddObjective("kill0", "Kill 8 Desert Chupacabra(s) or Zinute(s) or Lichenclops(s)", new KillObjective(8, 47329, 47327, 57039));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("ROKAS25_SQ_03", 1));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("ROKAS25_KEBIN", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS25_KEBIN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS25_SQ_02_selecet01", "ROKAS25_SQ_02", "I'll get you your lime", "I can't do such dirty job"))
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

		if (character.Inventory.HasItem("ROKAS25_FOOD", 8))
		{
			character.Inventory.RemoveItem("ROKAS25_FOOD", 8);
			await dialog.Msg("ROKAS25_SQ_02_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

