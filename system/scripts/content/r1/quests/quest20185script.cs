//--- Melia Script -----------------------------------------------------------
// Friend or Foe Error
//--- Description -----------------------------------------------------------
// Quest to Read the Royal Mausoleum gravestone.
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

[QuestScript(20185)]
public class Quest20185Script : QuestScript
{
	protected override void Load()
	{
		SetId(20185);
		SetName("Friend or Foe Error");
		SetDescription("Read the Royal Mausoleum gravestone");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA2F_MQ_04_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("kill0", "Kill 7 Echad(s)", new KillObjective(7, MonsterId.Echad));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1700));

		AddDialogHook("ZACHA2F_MQ_04", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA2F_MQ_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA2F_MQ_04_select01", "ZACHA2F_MQ_04", "Seems like it'd be better to defeat some guardians", "Ignore"))
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


		return HookResult.Break;
	}
}

