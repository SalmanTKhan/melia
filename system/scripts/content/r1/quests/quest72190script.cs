//--- Melia Script -----------------------------------------------------------
// The Poisoned Soldiers
//--- Description -----------------------------------------------------------
// Quest to Talk to the Medic.
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

[QuestScript(72190)]
public class Quest72190Script : QuestScript
{
	protected override void Load()
	{
		SetId(72190);
		SetName("The Poisoned Soldiers");
		SetDescription("Talk to the Medic");

		AddPrerequisite(new LevelPrerequisite(375));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_89_MQ_90"));

		AddObjective("collect0", "Collect 15 Schaffenstar Emergency Meds(s)", new CollectItemObjective("STARTOWER_89_SQ_10_ITEM", 15));
		AddDrop("STARTOWER_89_SQ_10_ITEM", 10f, "naste");

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 19500));

		AddDialogHook("D_STARTOWER_89_RESISTANCE_MEMBER_07", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_89_RESISTANCE_MEMBER_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_89_SQ_10_DLG1", "STARTOWER_89_SQ_10", "Tell me more.", "I've got other things to take care of."))
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

		if (character.Inventory.HasItem("STARTOWER_89_SQ_10_ITEM", 15))
		{
			character.Inventory.RemoveItem("STARTOWER_89_SQ_10_ITEM", 15);
			await dialog.Msg("STARTOWER_89_SQ_10_DLG3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

