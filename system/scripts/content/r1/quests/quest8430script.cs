//--- Melia Script -----------------------------------------------------------
// Liberation of Magic (1)
//--- Description -----------------------------------------------------------
// Quest to Read the epitaph.
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

[QuestScript(8430)]
public class Quest8430Script : QuestScript
{
	protected override void Load()
	{
		SetId(8430);
		SetName("Liberation of Magic (1)");
		SetDescription("Read the epitaph");

		AddPrerequisite(new LevelPrerequisite(83));

		AddObjective("collect0", "Collect 6 Activation Stone(s)", new CollectItemObjective("ZACHA1F_SQ_03_ITEM", 6));
		AddDrop("ZACHA1F_SQ_03_ITEM", 10f, 401301, 401121);

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1660));

		AddDialogHook("ZACHA1F_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA1F_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA1F_SQ_03", "ZACHA1F_SQ_03", "Let's gather the active stones", "I'll wait a little bit"))
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

		if (character.Inventory.HasItem("ZACHA1F_SQ_03_ITEM", 6))
		{
			character.Inventory.RemoveItem("ZACHA1F_SQ_03_ITEM", 6);
			ZoneServer.Instance.World.FindNPC("ZACHA1F_SQ_03")?.PlayEffectLocal(character.Connection, "F_circle020_light", 1f, "MID");
			await Task.Delay(1500);
			ZoneServer.Instance.World.FindNPC("ZACHA1F_SQ_03")?.PlayEffectLocal(character.Connection, "F_light003_yellow", 0.7f, "TOP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

