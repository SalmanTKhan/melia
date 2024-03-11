//--- Melia Script -----------------------------------------------------------
// Emergency (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Guardian Stone Statue.
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

[QuestScript(8437)]
public class Quest8437Script : QuestScript
{
	protected override void Load()
	{
		SetId(8437);
		SetName("Emergency (3)");
		SetDescription("Talk to the Guardian Stone Statue");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA2F_SQ_05_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(86));
		AddPrerequisite(new CompletedPrerequisite("ZACHA2F_SQ_04"));

		AddObjective("kill0", "Kill 7 Tombsinker(s) or Karas(s)", new KillObjective(7, 41277, 41274));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1720));

		AddDialogHook("ZACHA2F_SQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA2F_SQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA2F_SQ_05_01", "ZACHA2F_SQ_05", "I'll guard the Magic Vessel", "I'll wait a little bit"))
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

		await dialog.Msg("ZACHA2F_SQ_05_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

