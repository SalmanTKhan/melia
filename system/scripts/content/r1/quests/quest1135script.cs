//--- Melia Script -----------------------------------------------------------
// Guardian of Fedimian [Wizard Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Wizard Master.
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

[QuestScript(1135)]
public class Quest1135Script : QuestScript
{
	protected override void Load()
	{
		SetId(1135);
		SetName("Guardian of Fedimian [Wizard Advancement] (1)");
		SetDescription("Talk to the Wizard Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 4 Phyracon Fragment(s)", new CollectItemObjective("JOB_WIZARD3_1_ITEM1", 4));
		AddObjective("collect1", "Collect 13 Red Infrorocktor Shell Fragment(s)", new CollectItemObjective("JOB_WIZARD3_1_ITEM2", 13));
		AddDrop("JOB_WIZARD3_1_ITEM1", 2f, "flight_hope");
		AddDrop("JOB_WIZARD3_1_ITEM2", 8f, "InfroRocktor_red");

		AddDialogHook("MASTER_WIZARD", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_WIZARD", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_WIZARD3_1_select1", "JOB_WIZARD3_1", "I'll do anything for magic", "I'll come back later"))
		{
			case 1:
				await dialog.Msg("JOB_WIZARD3_1_agree1");
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

		if (character.Inventory.HasItem("JOB_WIZARD3_1_ITEM1", 4) && character.Inventory.HasItem("JOB_WIZARD3_1_ITEM2", 13))
		{
			character.Inventory.RemoveItem("JOB_WIZARD3_1_ITEM1", 4);
			character.Inventory.RemoveItem("JOB_WIZARD3_1_ITEM2", 13);
			await dialog.Msg("JOB_WIZARD3_1_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_WIZARD3_2");
	}
}

