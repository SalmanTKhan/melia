//--- Melia Script -----------------------------------------------------------
// The Journey to Find Myself (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon Lord Hauberk.
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

[QuestScript(60055)]
public class Quest60055Script : QuestScript
{
	protected override void Load()
	{
		SetId(60055);
		SetName("The Journey to Find Myself (4)");
		SetDescription("Talk to Demon Lord Hauberk");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM312_SQ_05_TRACK");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM312_SQ_04"));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 1760));

		AddDialogHook("PILGRIM312_HAUBERK_02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM312_HAUBERK_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM312_SQ_05_01", "PILGRIM312_SQ_05", "Tell him that you will do it", "I need some time to prepare"))
		{
			case 1:
				await dialog.Msg("PILGRIM312_SQ_05_AG");
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("PILGRIM312_SQ_05_1");
	}
}

