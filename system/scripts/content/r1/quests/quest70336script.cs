//--- Melia Script -----------------------------------------------------------
// Repairing the Goddess Statue [Dievdirbys Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Dievdirbys Submaster.
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

[QuestScript(70336)]
public class Quest70336Script : QuestScript
{
	protected override void Load()
	{
		SetId(70336);
		SetName("Repairing the Goddess Statue [Dievdirbys Advancement] (1)");
		SetDescription("Talk with Dievdirbys Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 20 Papayam Greasy Pulp(s)", new CollectItemObjective("JOB_2_DIEVDIRBYS5_ITEM", 20));
		AddDrop("JOB_2_DIEVDIRBYS5_ITEM", 8f, "Papayam");

		AddDialogHook("JOB_2_DIEVDIRBYS_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_DIEVDIRBYS_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_DIEVDIRBYS5_1_1", "JOB_2_DIEVDIRBYS5_1", "I will challenge it", "I think I will be fine with the things that I've learned so far"))
		{
			case 1:
				await dialog.Msg("JOB_2_DIEVDIRBYS5_1_2");
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


		return HookResult.Break;
	}
}

