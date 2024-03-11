//--- Melia Script -----------------------------------------------------------
// Non-existent Book [Linker Advancement] (1)
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

[QuestScript(1077)]
public class Quest1077Script : QuestScript
{
	protected override void Load()
	{
		SetId(1077);
		SetName("Non-existent Book [Linker Advancement] (1)");
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

		switch (await dialog.Select("JOB_LINKER2_1_select1", "JOB_LINKER2_1", "Prepare the materials for the test", "I need more time to think"))
		{
			case 1:
				await dialog.Msg("JOB_LINKER2_1_agree1");
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
			await dialog.Msg("JOB_LINKER2_1_succ1");
			ZoneServer.Instance.World.FindNPC("JOB_LINKER2_1_NPC")?.PlayEffectLocal(character.Connection, "archer_buff_skl_Prudence_circle", 1.5f, "BOT");
			await Task.Delay(800);
			character.PlayEffectLocal("archer_buff_skl_Prudence_circle");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_LINKER2_2");
	}
}

