//--- Melia Script -----------------------------------------------------------
// The End of Ebonypawn
//--- Description -----------------------------------------------------------
// Quest to Defeat Assassin Ebonypawn.
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

[QuestScript(30263)]
public class Quest30263Script : QuestScript
{
	protected override void Load()
	{
		SetId(30263);
		SetName("The End of Ebonypawn");
		SetDescription("Defeat Assassin Ebonypawn");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CASTLE_20_4_SQ_10_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_4_SQ_9"));

		AddObjective("collect0", "Collect 1 Assassin Ebonypawn's Mark", new CollectItemObjective("CASTLE_20_4_SQ_10_ITEM", 1));
		AddDrop("CASTLE_20_4_SQ_10_ITEM", 10f, "boss_ebonypawn");

		AddReward(new ExpReward(7261044, 7261044));
		AddReward(new ItemReward("expCard13", 5));
		AddReward(new ItemReward("Vis", 12138));

		AddDialogHook("CASTLE_20_4_NPC_1_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("CASTLE_20_4_SQ_10_ITEM", 1))
		{
			character.Inventory.RemoveItem("CASTLE_20_4_SQ_10_ITEM", 1);
			await dialog.Msg("CASTLE_20_4_SQ_10_succ");
			await dialog.Msg("FadeOutIN/500");
			dialog.HideNPC("CASTLE_20_4_NPC_1_AFTER");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

