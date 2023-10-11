//--- Melia Script -----------------------------------------------------------
// Old Story (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Coben.
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

[QuestScript(8458)]
public class Quest8458Script : QuestScript
{
	protected override void Load()
	{
		SetId(8458);
		SetName("Old Story (7)");
		SetDescription("Talk to Coben");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "REMAINS40_MQ_07_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(107));
		AddPrerequisite(new CompletedPrerequisite("REMAINS40_MQ_06"));

		AddObjective("kill0", "Kill 1 Cursed Devilglove", new KillObjective(1, MonsterId.Boss_Devilglove));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("REMAINS40_MQ_07_ITEM", 1));
		AddReward(new ItemReward("misc_liena_top_1", 1));
		AddReward(new ItemReward("Vis", 33384));

		AddDialogHook("REMAINS_40_DRUNK_03", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS_40_DRUNK_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS40_MQ_07_01", "REMAINS40_MQ_07", "Go and check what's written on the last tombstone.", "Decline"))
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

		await dialog.Msg("REMAINS40_MQ_07_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

