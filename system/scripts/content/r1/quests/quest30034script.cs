//--- Melia Script -----------------------------------------------------------
// Royal Army Corps Machine [Centurion Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Centurion Master.
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

[QuestScript(30034)]
public class Quest30034Script : QuestScript
{
	protected override void Load()
	{
		SetId(30034);
		SetName("Royal Army Corps Machine [Centurion Advancement]");
		SetDescription("Talk to the Centurion Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddObjective("collect0", "Collect 5 Royal Army's Torn Flag(s)", new CollectItemObjective("JOB_CENTURION_6_1_ITEM", 5));
		AddDrop("JOB_CENTURION_6_1_ITEM", 1f, "Fisherman");

		AddDialogHook("JOB_CENT4_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_CENT4_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CENTURION_6_1_select", "JOB_CENTURION_6_1", "I will certainly help", "I am not interested"))
		{
			case 1:
				await dialog.Msg("JOB_CENTURION_6_1_agree");
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

		if (character.Inventory.HasItem("JOB_CENTURION_6_1_ITEM", 5))
		{
			character.Inventory.RemoveItem("JOB_CENTURION_6_1_ITEM", 5);
			await dialog.Msg("JOB_CENTURION_6_1_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

