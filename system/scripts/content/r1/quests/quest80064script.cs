//--- Melia Script -----------------------------------------------------------
// Soldiers' Belongings
//--- Description -----------------------------------------------------------
// Quest to Collect the relics of the soldiers at Vedas Plateau.
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

[QuestScript(80064)]
public class Quest80064Script : QuestScript
{
	protected override void Load()
	{
		SetId(80064);
		SetName("Soldiers' Belongings");
		SetDescription("Collect the relics of the soldiers at Vedas Plateau");

		AddPrerequisite(new LevelPrerequisite(208));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_11_1_SQ_09"));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 7280));

		AddDialogHook("TABLELAND_11_1_LEMIJA3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("TABLELAND_11_1_SQ_13_OBJ", 6))
		{
			character.Inventory.RemoveItem("TABLELAND_11_1_SQ_13_OBJ", 6);
			await dialog.Msg("TABLELAND_11_1_SQ_13_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

