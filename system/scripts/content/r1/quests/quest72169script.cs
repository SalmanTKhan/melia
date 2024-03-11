//--- Melia Script -----------------------------------------------------------
// A Book Not of This World (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Linker Submaster.
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

[QuestScript(72169)]
public class Quest72169Script : QuestScript
{
	protected override void Load()
	{
		SetId(72169);
		SetName("A Book Not of This World (1)");
		SetDescription("Talk to the Linker Submaster");

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("collect0", "Collect 5 Corylus Core(s)", new CollectItemObjective("JOB_LINKER2_1_ITEM1", 5));
		AddObjective("collect1", "Collect 1 Galok Blood", new CollectItemObjective("JOB_LINKER2_1_ITEM2", 1));
		AddDrop("JOB_LINKER2_1_ITEM1", 7f, "Corylus");
		AddDrop("JOB_LINKER2_1_ITEM2", 10f, "Galok");

		AddDialogHook("JOB_LINKER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_LINKER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SUBMASTER_LINKER1_1_DLG1", "SUBMASTER_LINKER1_1", "Alright, I'll help you", "I need more time to think"))
		{
			case 1:
				await dialog.Msg("SUBMASTER_LINKER1_1_DLG2");
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

		if (character.Inventory.HasItem("JOB_LINKER2_1_ITEM1", 5) && character.Inventory.HasItem("JOB_LINKER2_1_ITEM2", 1))
		{
			character.Inventory.RemoveItem("JOB_LINKER2_1_ITEM1", 5);
			character.Inventory.RemoveItem("JOB_LINKER2_1_ITEM2", 1);
			await dialog.Msg("SUBMASTER_LINKER1_1_DLG3");
			await dialog.Msg("FadeOutIN/2000");
			await dialog.Msg("SUBMASTER_LINKER1_1_DLG4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SUBMASTER_LINKER1_2");
	}
}

