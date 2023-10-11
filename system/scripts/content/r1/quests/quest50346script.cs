//--- Melia Script -----------------------------------------------------------
// In to the Lion's Mouth (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Aistis.
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

[QuestScript(50346)]
public class Quest50346Script : QuestScript
{
	protected override void Load()
	{
		SetId(50346);
		SetName("In to the Lion's Mouth (3)");
		SetDescription("Talk to Monk Aistis");

		AddPrerequisite(new LevelPrerequisite(354));
		AddPrerequisite(new CompletedPrerequisite("ABBEY22_4_SQ2"));

		AddObjective("collect0", "Collect 22 Demon's Blood(s)", new CollectItemObjective("ABBEY22_4_SUBQ3_ITEM1", 22));
		AddDrop("ABBEY22_4_SUBQ3_ITEM1", 10f, "Hohen_mage_black");

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 18054));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("ABBEY22_4_SUBQ3_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY22_4_SUBQ3_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY22_4_SUBQ3_START1", "ABBEY22_4_SQ3", "Just say the word, and I'll help.", "I don't think that's a good idea."))
		{
			case 1:
				await dialog.Msg("ABBEY22_4_SUBQ3_AGR1");
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

		if (character.Inventory.HasItem("ABBEY22_4_SUBQ3_ITEM1", 22))
		{
			character.Inventory.RemoveItem("ABBEY22_4_SUBQ3_ITEM1", 22);
			await dialog.Msg("BalloonText/ABBEY22_4_SUBQ4_MSG1/5");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ABBEY22_4_SQ4");
	}
}

