//--- Melia Script -----------------------------------------------------------
// Purify Evil Aura [Priest Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Priest Master.
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

[QuestScript(8744)]
public class Quest8744Script : QuestScript
{
	protected override void Load()
	{
		SetId(8744);
		SetName("Purify Evil Aura [Priest Advancement]");
		SetDescription("Talk to the Priest Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_PRIEST5_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Shadowgaler", new KillObjective(1, MonsterId.Boss_ShadowGaoler));

		AddDialogHook("MASTER_PRIEST", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PRIEST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PRIEST5_1_01", "JOB_PRIEST5_1", "I will defeat them", "Decline"))
		{
			case 1:
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

		await dialog.Msg("JOB_PRIEST5_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

