//--- Melia Script -----------------------------------------------------------
// Poison Betrayal [Ranger Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Ranger Master.
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

[QuestScript(20130)]
public class Quest20130Script : QuestScript
{
	protected override void Load()
	{
		SetId(20130);
		SetName("Poison Betrayal [Ranger Advancement]");
		SetDescription("Talk to the Ranger Master");

		AddPrerequisite(new LevelPrerequisite(15));

		AddObjective("collect0", "Collect 15 Vubbe Venom Sample(s)", new CollectItemObjective("JOB_HUNTER1_Pileus", 15));
		AddDrop("JOB_HUNTER1_Pileus", 6f, "Goblin_Spear");

		AddObjective("kill0", "Kill 1 Vubbe Thief", new KillObjective(1, MonsterId.Goblin_Spear));

		AddDialogHook("MASTER_RANGER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_RANGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HUNTER1_select1", "JOB_HUNTER1", "I will accept the commission", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_HUNTER1_AG");
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

		if (character.Inventory.HasItem("JOB_HUNTER1_Pileus", 15))
		{
			character.Inventory.RemoveItem("JOB_HUNTER1_Pileus", 15);
			await dialog.Msg("JOB_HUNTER1_succc1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

