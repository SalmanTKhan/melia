//--- Melia Script -----------------------------------------------------------
// The History that Will Not Be Recorded (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Vaivora.
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

[QuestScript(60264)]
public class Quest60264Script : QuestScript
{
	protected override void Load()
	{
		SetId(60264);
		SetName("The History that Will Not Be Recorded (2)");
		SetDescription("Talk to Goddess Vaivora");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FANTASYLIB484_MQ_2_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(344));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB484_MQ_1"));

		AddObjective("kill0", "Kill 9 Rampal(s)", new KillObjective(9, MonsterId.Lampal));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));

		AddDialogHook("FLIBRARY484_VIVORA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY484_VIVORA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB484_MQ_2_1", "FANTASYLIB484_MQ_2", "I'll protect it with my life.", "I need to prepare"))
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

		await dialog.Msg("FANTASYLIB484_MQ_2_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

