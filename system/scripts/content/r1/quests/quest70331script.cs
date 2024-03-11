//--- Melia Script -----------------------------------------------------------
// Traces of My Seniors [Hoplite Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hoplite Master.
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

[QuestScript(70331)]
public class Quest70331Script : QuestScript
{
	protected override void Load()
	{
		SetId(70331);
		SetName("Traces of My Seniors [Hoplite Advancement]");
		SetDescription("Talk to the Hoplite Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 15 Hoplites' Broken Spear Parts(s)", new CollectItemObjective("JOB_2_HOPLITE5_ITEM1", 15));
		AddDrop("JOB_2_HOPLITE5_ITEM1", 7.5f, 57279, 57282, 57647);

		AddDialogHook("JOB_2_HOPLITE_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_HOPLITE_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_HOPLITE5_1_1", "JOB_2_HOPLITE5", "I am ready", "I need more training"))
		{
			case 1:
				await dialog.Msg("JOB_2_HOPLITE5_1_2");
				dialog.UnHideNPC("JOB_2_HOPLITE_ARMOR");
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

