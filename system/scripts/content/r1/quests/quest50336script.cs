//--- Melia Script -----------------------------------------------------------
// Narvas Temple's Barrier (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Aistis.
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

[QuestScript(50336)]
public class Quest50336Script : QuestScript
{
	protected override void Load()
	{
		SetId(50336);
		SetName("Narvas Temple's Barrier (2)");
		SetDescription("Talk to Monk Aistis");

		AddPrerequisite(new LevelPrerequisite(351));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_3_SQ1"));

		AddObjective("collect0", "Collect 35 Essence of Hohen(s)", new CollectItemObjective("WTREES22_3_SUBQ2_ITEM1", 35));
		AddDrop("WTREES22_3_SUBQ2_ITEM1", 10f, "yakmab");

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 17901));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("WTREES22_3_SUBQ1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES22_3_SUBQ1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_3_SUBQ2_START1", "WTREES22_3_SQ2", "I'll help you", "Request others for help."))
		{
			case 1:
				await dialog.Msg("WTREES22_3_SUBQ2_AGG1");
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

		if (character.Inventory.HasItem("WTREES22_3_SUBQ2_ITEM1", 35))
		{
			character.Inventory.RemoveItem("WTREES22_3_SUBQ2_ITEM1", 35);
			await dialog.Msg("WTREES22_3_SUBQ2_SUCC1");
			// Func/SCR_WTREES22_3_SUBQ2_COMP;
			await dialog.Msg("WTREES22_3_SUBQ2_SUCC2");
			dialog.UnHideNPC("WTREES22_3_SUBQ1_NPC2");
			dialog.HideNPC("WTREES22_3_SUBQ1_NPC1");
			await dialog.Msg("FadeOutIN/1000");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

