//--- Melia Script -----------------------------------------------------------
// Astral Lens
//--- Description -----------------------------------------------------------
// Quest to Talk to the Quarrel Shooter Master.
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

[QuestScript(72165)]
public class Quest72165Script : QuestScript
{
	protected override void Load()
	{
		SetId(72165);
		SetName("Astral Lens");
		SetDescription("Talk to the Quarrel Shooter Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_QUARRELSHOOTER1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(15));

		AddObjective("collect0", "Collect 1 Astral Tower Lens", new CollectItemObjective("JOB_QUARRELSHOOTER1_Lens", 1));
		AddDrop("JOB_QUARRELSHOOTER1_Lens", 10f, "boss_ShadowGaoler_J1");

		AddObjective("kill0", "Kill 1 Shadowgaler", new KillObjective(1, MonsterId.Boss_ShadowGaoler_J1));

		AddReward(new ItemReward("Point_Stone_100_Q", 1));

		AddDialogHook("MASTER_QU", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_QU", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MASTER_QUARRELSHOOTER1_DLG1", "MASTER_QUARRELSHOOTER1", "I'll do you this favor", "Sounds suspicious, I'll have to decline"))
		{
			case 1:
				await dialog.Msg("MASTER_QUARRELSHOOTER1_DLG2");
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

		if (character.Inventory.HasItem("JOB_QUARRELSHOOTER1_Lens", 1))
		{
			character.Inventory.RemoveItem("JOB_QUARRELSHOOTER1_Lens", 1);
			await dialog.Msg("MASTER_QUARRELSHOOTER1_DLG3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

