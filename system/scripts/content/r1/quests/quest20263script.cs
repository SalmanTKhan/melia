//--- Melia Script -----------------------------------------------------------
// The Art of Interference
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Evaldas.
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

[QuestScript(20263)]
public class Quest20263Script : QuestScript
{
	protected override void Load()
	{
		SetId(20263);
		SetName("The Art of Interference");
		SetDescription("Talk to Believer Evaldas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN20_MQ03_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(61));

		AddObjective("kill0", "Kill 3 Merog Shaman(s)", new KillObjective(3, MonsterId.Merog_Wizzard));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("THORN20_MQ03_TRACK", "BeforeStart", BeforeStart);
		AddDialogHook("THORN20_MQ03_TRACK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN20_MQ03_select01", "THORN20_MQ03", "I can give it a try", "I don't feel it"))
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

		await dialog.Msg("THORN20_MQ03_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

