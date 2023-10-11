//--- Melia Script -----------------------------------------------------------
// Repair the Practice Wooden Seal (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Highlander Master.
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

[QuestScript(9101)]
public class Quest9101Script : QuestScript
{
	protected override void Load()
	{
		SetId(9101);
		SetName("Repair the Practice Wooden Seal (1)");
		SetDescription("Talk to the Highlander Master");

		AddPrerequisite(new LevelPrerequisite(119));

		AddObjective("collect0", "Collect 5 Hardened Tree Log(s)", new CollectItemObjective("WOOD_CARVING_REPAIR_WOOD", 5));
		AddObjective("collect1", "Collect 1 Rope", new CollectItemObjective("WOOD_CARVING_REPAIR_ROPE", 1));
		AddDrop("WOOD_CARVING_REPAIR_WOOD", 7.5f, "Firent");
		AddDrop("WOOD_CARVING_REPAIR_ROPE", 1f, "Npanto_archer");

		AddDialogHook("MASTER_HIGHLANDER", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("HIGHLANDER_HQ_01_select01", "HIGHLANDER_HQ_01", "I will repair the practice wooden seal", "Decline"))
		{
			case 1:
				await dialog.Msg("HIGHLANDER_HQ_01_startnpc01");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("HIGHLANDER_HQ_02");
	}
}

