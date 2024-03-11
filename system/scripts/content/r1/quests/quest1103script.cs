//--- Melia Script -----------------------------------------------------------
// Duty of the Pledge [Peltasta Advancement](1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Peltasta Master.
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

[QuestScript(1103)]
public class Quest1103Script : QuestScript
{
	protected override void Load()
	{
		SetId(1103);
		SetName("Duty of the Pledge [Peltasta Advancement](1)");
		SetDescription("Talk to the Peltasta Master");

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("collect0", "Collect 2 Glizardon's Black Nails(s)", new CollectItemObjective("JOB_PELTASTA2_1_ITEM", 2));
		AddDrop("JOB_PELTASTA2_1_ITEM", 10f, "Glizardon");

		AddDialogHook("MASTER_PELTASTA", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_HIGHLANDER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PELTASTA2_1_select1", "JOB_PELTASTA2_1", "Ask what you should do", "I am not responsible to do it"))
		{
			case 1:
				await dialog.Msg("JOB_PELTASTA2_1_AG");
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

		if (character.Inventory.HasItem("JOB_PELTASTA2_1_ITEM", 2))
		{
			character.Inventory.RemoveItem("JOB_PELTASTA2_1_ITEM", 2);
			await dialog.Msg("JOB_PELTASTA2_1_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_PELTASTA2_2");
	}
}

