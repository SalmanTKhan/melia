//--- Melia Script -----------------------------------------------------------
// Release Goddess Saule (4)
//--- Description -----------------------------------------------------------
// Quest to Release the Demon Barrier.
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

[QuestScript(18007)]
public class Quest18007Script : QuestScript
{
	protected override void Load()
	{
		SetId(18007);
		SetName("Release Goddess Saule (4)");
		SetDescription("Release the Demon Barrier");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "HUEVILLAGE_58_4_MQ07_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(55));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_4_MQ06"));
		AddPrerequisite(new ItemPrerequisite("HUEVILLAGE_58_4_MQ05_ITEM1", -100));

		AddObjective("collect0", "Collect 1 Confinement Key", new CollectItemObjective("HUEVILLAGE_58_4_MQ07_ITEM1", 1));
		AddDrop("HUEVILLAGE_58_4_MQ07_ITEM1", 10f, "boss_Clymen");

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));
		AddReward(new ItemReward("TreasureboxKey2", 1));
		AddReward(new ItemReward("Vis", 990));

		AddDialogHook("HUEVILLAGE_58_4_MQ07_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_4_SAULE_BEFORE", "BeforeEnd", BeforeEnd);
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

		if (character.Inventory.HasItem("HUEVILLAGE_58_4_MQ07_ITEM1", 1))
		{
			character.Inventory.RemoveItem("HUEVILLAGE_58_4_MQ07_ITEM1", 1);
			await dialog.Msg("HUEVILLAGE_58_4_MQ07_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("HUEVILLAGE_58_4_MQ08");
	}
}

