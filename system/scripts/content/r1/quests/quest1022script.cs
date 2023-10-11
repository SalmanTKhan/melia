//--- Melia Script -----------------------------------------------------------
// The Beginning of Trouble
//--- Description -----------------------------------------------------------
// Quest to Talk to the Battle Commander.
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

[QuestScript(1022)]
public class Quest1022Script : QuestScript
{
	protected override void Load()
	{
		SetId(1022);
		SetName("The Beginning of Trouble");
		SetDescription("Talk to the Battle Commander");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAUL_WEST_BOSS_GOLEM_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(4));

		AddObjective("kill0", "Kill 1 Golem", new KillObjective(1, MonsterId.Boss_Golem));

		AddReward(new ExpReward(1500, 1500));
		AddReward(new ItemReward("expCard1", 3));
		AddReward(new ItemReward("Drug_Haste1_Q", 3));
		AddReward(new ItemReward("Vis", 52));

		AddDialogHook("SIAUL_WEST_SOL3", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_WEST_SOL3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_WEST_BOSS_GOLEM_ST", "SIAUL_WEST_BOSS_GOLEM", "I'll try to look for them", "They will be back soon"))
		{
			case 1:
				await dialog.Msg("SIAUL_WEST_BOSS_GOLEM_AC");
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

		await dialog.Msg("SIAUL_WEST_BOSS_GOLEM_dlg4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

