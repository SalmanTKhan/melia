//--- Melia Script -----------------------------------------------------------
// Supporting the Royal Army at Dvasia Peak [Chaplain Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Chaplain Master.
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

[QuestScript(30129)]
public class Quest30129Script : QuestScript
{
	protected override void Load()
	{
		SetId(30129);
		SetName("Supporting the Royal Army at Dvasia Peak [Chaplain Advancement]");
		SetDescription("Talk to the Chaplain Master");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("collect0", "Collect 50 Lost Materials(s)", new CollectItemObjective("JOB_CHAPLAIN_5_1_ITEM", 50));
		AddDrop("JOB_CHAPLAIN_5_1_ITEM", 10f, 41285, 41269, 41290, 41264);

		AddDialogHook("CHAPLAIN_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPLAIN_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CHAPLAIN_5_1_select", "JOB_CHAPLAIN_5_1", "I'll help the Royal Army", "It does not concern you"))
		{
			case 1:
				await dialog.Msg("JOB_CHAPLAIN_5_1_agree");
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

		if (character.Inventory.HasItem("JOB_CHAPLAIN_5_1_ITEM", 50))
		{
			character.Inventory.RemoveItem("JOB_CHAPLAIN_5_1_ITEM", 50);
			await dialog.Msg("JOB_CHAPLAIN_5_1_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

