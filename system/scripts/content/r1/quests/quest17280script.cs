//--- Melia Script -----------------------------------------------------------
// Two Birds with One Stone
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Basil.
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

[QuestScript(17280)]
public class Quest17280Script : QuestScript
{
	protected override void Load()
	{
		SetId(17280);
		SetName("Two Birds with One Stone");
		SetDescription("Talk to Watcher Basil");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "GELE572_MQ_09_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(29));

		AddObjective("collect0", "Collect 1 Enchanted Mane", new CollectItemObjective("GELE572_MQ_05_ITEM", 1));
		AddDrop("GELE572_MQ_05_ITEM", 10f, "boss_Mushcaria_Q2");

		AddReward(new ExpReward(8058, 8058));
		AddReward(new ItemReward("expCard2", 3));
		AddReward(new ItemReward("Hat_628016", 1));
		AddReward(new ItemReward("Vis", 3654));

		AddDialogHook("GELE572_NPC_BASIL", "BeforeStart", BeforeStart);
		AddDialogHook("GELE572_NPC_BASIL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE572_MQ_09_01", "GELE572_MQ_09", "I'll get it", "Decline"))
		{
			case 1:
				dialog.UnHideNPC("GELE572_MQ_09");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("GELE572_MQ_05_ITEM", 1))
		{
			character.Inventory.RemoveItem("GELE572_MQ_05_ITEM", 1);
			await dialog.Msg("GELE572_MQ_09_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

