//--- Melia Script -----------------------------------------------------------
// The Story of Anastos
//--- Description -----------------------------------------------------------
// Quest to Talk to Gedas.
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

[QuestScript(41100)]
public class Quest41100Script : QuestScript
{
	protected override void Load()
	{
		SetId(41100);
		SetName("The Story of Anastos");
		SetDescription("Talk to Gedas");

		AddPrerequisite(new LevelPrerequisite(106));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_36_2_SQ_090"));

		AddObjective("collect0", "Collect 19 Flammable Powder(s)", new CollectItemObjective("PILGRIM_36_2_SQ_100_ITEM_1", 19));
		AddDrop("PILGRIM_36_2_SQ_100_ITEM_1", 10f, 58107, 58126, 58127, 58130);

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2544));

		AddDialogHook("PILGRIM_36_2_GEDAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_GEDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_36_2_SQ_100_ST", "PILGRIM_36_2_SQ_100", "I will help with the investigation of Albinas", "Go out now"))
		{
			case 1:
				await dialog.Msg("PILGRIM_36_2_SQ_100_AC");
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

		if (character.Inventory.HasItem("PILGRIM_36_2_SQ_100_ITEM_1", 19))
		{
			character.Inventory.RemoveItem("PILGRIM_36_2_SQ_100_ITEM_1", 19);
			await dialog.Msg("PILGRIM_36_2_SQ_100_COMP");
			await Task.Delay(1000);
			ZoneServer.Instance.World.FindNPC("PILGRIM_36_2_GEDAS")?.PlayEffectLocal(character.Connection, "F_circle004_rize", 8f, "MID");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

