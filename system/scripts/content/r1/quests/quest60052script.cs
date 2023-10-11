//--- Melia Script -----------------------------------------------------------
// The Journey to Find Myself (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon Lord Hauberk.
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

[QuestScript(60052)]
public class Quest60052Script : QuestScript
{
	protected override void Load()
	{
		SetId(60052);
		SetName("The Journey to Find Myself (1)");
		SetDescription("Talk to Demon Lord Hauberk");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM312_SQ_02_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM312_SQ_01"));

		AddObjective("kill0", "Kill 6 Desmodus(s)", new KillObjective(6, MonsterId.Sec_New_Desmodus));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 1760));

		AddDialogHook("PILGRIM312_HAUBERK_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM312_HAUBERK_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM312_SQ_02_01", "PILGRIM312_SQ_02", "Tell him that you will feed him the detoxifying herb", "Look little more"))
		{
			case 1:
				// Func/PILGRIM312_SQ_02_01_ADD;
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


		return HookResult.Break;
	}
}

