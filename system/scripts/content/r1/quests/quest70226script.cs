//--- Melia Script -----------------------------------------------------------
// Priority
//--- Description -----------------------------------------------------------
// Quest to Talk with Mortimer.
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

[QuestScript(70226)]
public class Quest70226Script : QuestScript
{
	protected override void Load()
	{
		SetId(70226);
		SetName("Priority");
		SetDescription("Talk with Mortimer");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "TABLELAND28_2_SQ07_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(215));

		AddObjective("kill0", "Kill 1 Blue Sparnashorn", new KillObjective(1, MonsterId.Boss_Sparnashorn_Blue));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 5));
		AddReward(new ItemReward("Vis", 7525));

		AddDialogHook("TABLELAND282_SQ_07", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND282_SQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND28_2_SQ_07_1", "TABLELAND28_2_SQ07", "I will kick out Sparnashorn for you", "It can't be done "))
		{
			case 1:
				await dialog.Msg("TABLELAND28_2_SQ_07_2");
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

		await dialog.Msg("TABLELAND28_2_SQ_07_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

