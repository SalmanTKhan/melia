//--- Melia Script -----------------------------------------------------------
// Unfinished Commission (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Archaeologist Laudi.
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

[QuestScript(8030)]
public class Quest8030Script : QuestScript
{
	protected override void Load()
	{
		SetId(8030);
		SetName("Unfinished Commission (1)");
		SetDescription("Talk to Archaeologist Laudi");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS26_QUEST01_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(64));

		AddObjective("collect0", "Collect 1 Relic Fragment", new CollectItemObjective("ROKAS26_M_SLATE", 1));
		AddDrop("ROKAS26_M_SLATE", 10f, "boss_Denoptic");

		AddObjective("kill0", "Kill 1 Denoptic", new KillObjective(1, MonsterId.Boss_Denoptic));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("misc_Denoptic", 1));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("ROKAS26_REXIPHER1", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS26_REXIPHER1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS26_QUEST01_1", "ROKAS26_QUEST01", "I will find the artifacts", "About the monsters that eat stones", "Tell him to look for more stronger person"))
		{
			case 1:
				await dialog.Msg("ROKAS26_QUEST01_4");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("ROKAS26_QUEST01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("ROKAS26_M_SLATE", 1))
		{
			character.Inventory.RemoveItem("ROKAS26_M_SLATE", 1);
			await dialog.Msg("ROKAS26_QUEST01_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS26_QUEST02");
	}
}

