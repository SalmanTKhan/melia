//--- Melia Script -----------------------------------------------------------
// I Can Hear You Singing (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Indrea.
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

[QuestScript(50318)]
public class Quest50318Script : QuestScript
{
	protected override void Load()
	{
		SetId(50318);
		SetName("I Can Hear You Singing (3)");
		SetDescription("Talk to Indrea");

		AddPrerequisite(new LevelPrerequisite(344));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_1_SQ2"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 16512));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("WTREES221_SUBQ_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES221_SUBQ_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_1_SUBQ3_START1", "WTREES22_1_SQ3", "Go look for Teresh pollen.", "I have some urgent thing to do"))
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

		if (character.Inventory.HasItem("WTREES22_1_SUBQ3_ITEM1", 15))
		{
			character.Inventory.RemoveItem("WTREES22_1_SUBQ3_ITEM1", 15);
			await dialog.Msg("WTREES22_1_SUBQ3_SUCC1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

