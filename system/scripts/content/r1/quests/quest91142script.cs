//--- Melia Script -----------------------------------------------------------
// Where Ominous Energy Leaks From (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(91142)]
public class Quest91142Script : QuestScript
{
	protected override void Load()
	{
		SetId(91142);
		SetName("Where Ominous Energy Leaks From (1)");
		SetDescription("Talk to Pajauta");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP14_2_DCASTLE1_MQ_9_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(470));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE1_MQ_8"));

		AddObjective("collect0", "Collect 1 Barrier Removal Scroll", new CollectItemObjective("EP14_2_DCASTLE1_MQ_9_ITEM1", 1));
		AddDrop("EP14_2_DCASTLE1_MQ_9_ITEM1", 0.5f, 59743, 59742);

		AddReward(new ExpReward(2400000000, 2400000000));
		AddReward(new ItemReward("Vis", 60490));

		AddDialogHook("EP14_2_1_PAJAUTA2", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_2_1_Lamin2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("EP14_2_DCASTLE1_MQ_9_ITEM1", 1))
		{
			character.Inventory.RemoveItem("EP14_2_DCASTLE1_MQ_9_ITEM1", 1);
			await dialog.Msg("EP14_2_DCASTLE1_MQ_9_DLG2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

