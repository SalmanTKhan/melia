//--- Melia Script -----------------------------------------------------------
// Flurry's Epitaphs (6)
//--- Description -----------------------------------------------------------
// Quest to Find Agailla Flurry's gravestones .
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

[QuestScript(20219)]
public class Quest20219Script : QuestScript
{
	protected override void Load()
	{
		SetId(20219);
		SetName("Flurry's Epitaphs (6)");
		SetDescription("Find Agailla Flurry's gravestones ");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "REMAINS39_MQ07_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(103));
		AddPrerequisite(new CompletedPrerequisite("REMAINS39_MQ06"));

		AddObjective("kill0", "Kill 1 Reaverpede", new KillObjective(1, MonsterId.Boss_Reaverpede));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("misc_liena_pants_2", 1));
		AddReward(new ItemReward("Vis", 37080));

		AddDialogHook("REMAINS39_MQ_MONUMENT6", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS39_MQ_MONUMENT6", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("REMAINS39_MQ07_succ01");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You've read all of Agailla Flurry's epitaphs{nl}Your status has increased by 1!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

