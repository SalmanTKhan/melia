//--- Melia Script -----------------------------------------------------------
// Don't Panic
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Zaneta.
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

[QuestScript(20264)]
public class Quest20264Script : QuestScript
{
	protected override void Load()
	{
		SetId(20264);
		SetName("Don't Panic");
		SetDescription("Talk to Believer Zaneta");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN20_MQ04_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(61));

		AddObjective("kill0", "Kill 2 Demon Summoning Crystal(s)", new KillObjective(2, MonsterId.Npc_Pollution_Crystal));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("THORN20_MQ04_TRACK", "BeforeStart", BeforeStart);
		AddDialogHook("THORN20_MQ04_TRACK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN20_MQ04_select01", "THORN20_MQ04", "I will destroy the summon crystal", "You'll be able to run away"))
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

		await dialog.Msg("THORN20_MQ04_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

