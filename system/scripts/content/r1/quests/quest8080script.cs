//--- Melia Script -----------------------------------------------------------
// Kidnapped Villagers
//--- Description -----------------------------------------------------------
// Quest to Talk to the Miners' Village Mayor.
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

[QuestScript(8080)]
public class Quest8080Script : QuestScript
{
	protected override void Load()
	{
		SetId(8080);
		SetName("Kidnapped Villagers");
		SetDescription("Talk to the Miners' Village Mayor");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAU_OUT_ALCHE_TRACK", 1000);

		AddPrerequisite(new LevelPrerequisite(11));
		AddPrerequisite(new CompletedPrerequisite("SOUT_Q_01"));

		AddObjective("kill0", "Kill 5 Vubbe Thief(s) or Vubbe Archer(s)", new KillObjective(5, 11120, 57266));

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 221));

		AddDialogHook("SIAULIAIOUT_CHIEF_A", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_ALCHE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SOUT_Q_11_1", "SOUT_Q_14", "Ask how to enter the Crystal Mine", "Take time to think for a while"))
		{
			case 1:
				await dialog.Msg("SOUT_Q_11_1_09");
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

		await dialog.Msg("SOUT_Q_14_3");
		await dialog.Msg("FadeOutIN/300");
		dialog.UnHideNPC("SIAULIAIOUT_ALCHE_A");
		dialog.HideNPC("SIAULIAIOUT_ALCHE");
		dialog.ShowHelp("TUTO_CAMPFIRE");
		dialog.UnHideNPC("SIAULIAIOUT_SOLDIRE_SQ31");
		dialog.UnHideNPC("SIAULIAIOUT_SOLDIRE_SQ32");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

