//--- Melia Script -----------------------------------------------------------
// Last Mission (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Officer's Spirit.
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

[QuestScript(8230)]
public class Quest8230Script : QuestScript
{
	protected override void Load()
	{
		SetId(8230);
		SetName("Last Mission (5)");
		SetDescription("Talk to the Officer's Spirit");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN71_MQ_06_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(107));
		AddPrerequisite(new CompletedPrerequisite("KATYN71_MQ_05"));

		AddObjective("kill0", "Kill 10 Ellom(s) or Fisherman(s) or Bushspider(s)", new KillObjective(10, 41436, 400341, 400141));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("KATYN71_OFFICER_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN71_OFFICER_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN71_MQ_06_01", "KATYN71_MQ_06", "I will clear the mission", "It seems dangerous. I quit."))
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

		await dialog.Msg("KATYN71_MQ_06_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

