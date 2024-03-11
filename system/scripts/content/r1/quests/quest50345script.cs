//--- Melia Script -----------------------------------------------------------
// In to the Lion's Mouth (2)
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

[QuestScript(50345)]
public class Quest50345Script : QuestScript
{
	protected override void Load()
	{
		SetId(50345);
		SetName("In to the Lion's Mouth (2)");
		SetDescription("Talk to Monk Aistis");

		AddPrerequisite(new LevelPrerequisite(354));
		AddPrerequisite(new CompletedPrerequisite("ABBEY22_4_SQ1"));

		AddObjective("collect0", "Collect 20 Strong Essence of Demon(s)", new CollectItemObjective("ABBEY22_4_SUBQ2_ITEM1", 20));
		AddDrop("ABBEY22_4_SUBQ2_ITEM1", 10f, "Hohen_mage_black");

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 18054));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("ABBEY22_4_SUBQ2_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY22_4_SUBQ2_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY22_4_SUBQ2_START1", "ABBEY22_4_SQ2", "Won't the demons notice us?", "Let's look for other energy sources."))
		{
			case 1:
				await dialog.Msg("ABBEY22_4_SUBQ2_AGR1");
				await dialog.Msg("BalloonText/ABBEY22_4_SUBQ2_INFOR1/7");
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

		if (character.Inventory.HasItem("ABBEY22_4_SUBQ2_ITEM1", 20))
		{
			character.Inventory.RemoveItem("ABBEY22_4_SUBQ2_ITEM1", 20);
			await dialog.Msg("ABBEY22_4_SUBQ2_SUCC1");
			dialog.HideNPC("ABBEY22_4_SUBQ2_NPC1");
			dialog.UnHideNPC("ABBEY22_4_SUBQ3_NPC1");
			await dialog.Msg("FadeOutIN/1000");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

