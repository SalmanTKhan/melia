//--- Melia Script -----------------------------------------------------------
// The Battle
//--- Description -----------------------------------------------------------
// Quest to Talk to Assistant Commander Talon.
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

[QuestScript(50154)]
public class Quest50154Script : QuestScript
{
	protected override void Load()
	{
		SetId(50154);
		SetName("The Battle");
		SetDescription("Talk to Assistant Commander Talon");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "TABLELAND_70_SQ9_TRACK", "boss_a");

		AddPrerequisite(new LevelPrerequisite(238));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_70_SQ8"));

		AddObjective("kill0", "Kill 1 Centaurus", new KillObjective(1, MonsterId.Boss_Centaurus_Q1));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("expCard12", 5));
		AddReward(new ItemReward("Vis", 8568));

		AddDialogHook("TABLE70_CAPTIN1_3", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE70_CAPTIN1_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_70_SQ9_startnpc01", "TABLELAND_70_SQ9", "I'm ready to fight the demons", "I'm not ready yet"))
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

		await dialog.Msg("TABLELAND_70_SQ9_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

