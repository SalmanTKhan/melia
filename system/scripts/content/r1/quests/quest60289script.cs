//--- Melia Script -----------------------------------------------------------
// Think Back
//--- Description -----------------------------------------------------------
// Quest to Talk to the rescued Kupole.
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

[QuestScript(60289)]
public class Quest60289Script : QuestScript
{
	protected override void Load()
	{
		SetId(60289);
		SetName("Think Back");
		SetDescription("Talk to the rescued Kupole");

		AddPrerequisite(new LevelPrerequisite(371));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL105_SQ_8"));

		AddObjective("collect0", "Collect 5 Kupoles' Belongings(s)", new CollectItemObjective("DCAPITAL105_SQ_9_ITEM", 5));
		AddDrop("DCAPITAL105_SQ_9_ITEM", 10f, "bishopstar");

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 19000));

		AddDialogHook("DCAPITAL105_KUPOLE_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL105_KUPOLE_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL105_SQ_9_1", "DCAPITAL105_SQ_9", "I can retrieve it.", "You worry too much."))
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

		if (character.Inventory.HasItem("DCAPITAL105_SQ_9_ITEM", 5))
		{
			character.Inventory.RemoveItem("DCAPITAL105_SQ_9_ITEM", 5);
			await dialog.Msg("DCAPITAL105_SQ_9_3");
			await dialog.Msg("FadeOutIN/1800");
			dialog.HideNPC("DCAPITAL105_KUPOLE_NPC");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

