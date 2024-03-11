//--- Melia Script -----------------------------------------------------------
// Why on Medzio Diena... (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Liepa.
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

[QuestScript(30242)]
public class Quest30242Script : QuestScript
{
	protected override void Load()
	{
		SetId(30242);
		SetName("Why on Medzio Diena... (2)");
		SetDescription("Talk to Kupole Liepa");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_2_SQ_11"));

		AddObjective("collect0", "Collect 1 Emergency Orders", new CollectItemObjective("CASTLE_20_2_SQ_12_ITEM", 1));
		AddDrop("CASTLE_20_2_SQ_12_ITEM", 1f, 58607, 58612, 58608);

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("CASTLE_20_2_NPC_1_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_2_NPC_1_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE_20_2_SQ_12_select", "CASTLE_20_2_SQ_12", "I will investigate the Meeting Room.", "I don't think there would be anything important there."))
		{
			case 1:
				await dialog.Msg("CASTLE_20_2_SQ_12_agree");
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

		if (character.Inventory.HasItem("CASTLE_20_2_SQ_12_ITEM", 1))
		{
			character.Inventory.RemoveItem("CASTLE_20_2_SQ_12_ITEM", 1);
			await dialog.Msg("CASTLE_20_2_SQ_12_succ");
			dialog.UnHideNPC("CASTLE_20_1_NPC_1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

