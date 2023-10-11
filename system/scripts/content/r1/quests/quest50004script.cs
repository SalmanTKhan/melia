//--- Melia Script -----------------------------------------------------------
// A Soldier's Favor
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Jace.
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

[QuestScript(50004)]
public class Quest50004Script : QuestScript
{
	protected override void Load()
	{
		SetId(50004);
		SetName("A Soldier's Favor");
		SetDescription("Talk to Soldier Jace");

		AddPrerequisite(new LevelPrerequisite(11));
		AddPrerequisite(new CompletedPrerequisite("SOUT_Q_14"));

		AddObjective("collect0", "Collect 6 Soldier's Memento(s)", new CollectItemObjective("SOLDIRE_SQ31_RELIC", 6));
		AddDrop("SOLDIRE_SQ31_RELIC", 6f, "Goblin_Spear");

		AddReward(new ExpReward(10744, 10744));
		AddReward(new ItemReward("expCard2", 4));
		AddReward(new ItemReward("Vis", 143));

		AddDialogHook("SIAULIAIOUT_SOLDIRE_SQ31", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_SOLDIRE_SQ31", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SOUT_Q_31_SELECT01", "SOUT_Q_31", "I'll gather the mementos", "Decline"))
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

		if (character.Inventory.HasItem("SOLDIRE_SQ31_RELIC", 6))
		{
			character.Inventory.RemoveItem("SOLDIRE_SQ31_RELIC", 6);
			await dialog.Msg("SOUT_Q_31_SUCC01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

