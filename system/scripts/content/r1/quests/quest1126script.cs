//--- Melia Script -----------------------------------------------------------
// Careful Move [Sapper Advancement](1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sapper Master.
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

[QuestScript(1126)]
public class Quest1126Script : QuestScript
{
	protected override void Load()
	{
		SetId(1126);
		SetName("Careful Move [Sapper Advancement](1)");
		SetDescription("Talk to the Sapper Master");

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("collect0", "Collect 30 Burnable Juice of Tontulia(s)", new CollectItemObjective("JOB_SAPPER3_1_ITEM1", 30));
		AddDrop("JOB_SAPPER3_1_ITEM1", 10f, "Tontulia");

		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SAPPER3_1_select1", "JOB_SAPPER3_1", "Get the materials needed", "Decline"))
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

		if (character.Inventory.HasItem("JOB_SAPPER3_1_ITEM1", 30))
		{
			character.Inventory.RemoveItem("JOB_SAPPER3_1_ITEM1", 30);
			await dialog.Msg("JOB_SAPPER3_1_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_SAPPER3_2");
	}
}

