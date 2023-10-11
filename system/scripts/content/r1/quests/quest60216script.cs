//--- Melia Script -----------------------------------------------------------
// Alembique Tales(7)
//--- Description -----------------------------------------------------------
// Quest to Return to Priest Celvica.
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

[QuestScript(60216)]
public class Quest60216Script : QuestScript
{
	protected override void Load()
	{
		SetId(60216);
		SetName("Alembique Tales(7)");
		SetDescription("Return to Priest Celvica");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "LSCAVE551_SQ_7_TRACK", "boss_a");

		AddPrerequisite(new LevelPrerequisite(320));
		AddPrerequisite(new CompletedPrerequisite("LSCAVE551_SQ_7"));

		AddObjective("collect0", "Collect 1 Edeline's Silver Necklace", new CollectItemObjective("LSCAVE551_SQ_7_ITEM", 1));
		AddDrop("LSCAVE551_SQ_7_ITEM", 10f, "boss_Ravinepede_Q1");

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 15040));

		AddDialogHook("LSCAVE551_CELVERKA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("LSCAVE551_CELVERKA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LSCAVE551_SQ_8_1", "LSCAVE551_SQ_8", "I will find Edeline.", "I need to prepare"))
		{
			case 1:
				dialog.UnHideNPC("LSCAVE551_SQ_7_NPC");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("LSCAVE551_SQ_7_ITEM", 1))
		{
			character.Inventory.RemoveItem("LSCAVE551_SQ_7_ITEM", 1);
			await dialog.Msg("LSCAVE551_SQ_8_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

