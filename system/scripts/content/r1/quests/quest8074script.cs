//--- Melia Script -----------------------------------------------------------
// Mine Manager Brinker's Dedication (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Mine Manager Brinker.
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

[QuestScript(8074)]
public class Quest8074Script : QuestScript
{
	protected override void Load()
	{
		SetId(8074);
		SetName("Mine Manager Brinker's Dedication (2)");
		SetDescription("Talk to Mine Manager Brinker");

		AddPrerequisite(new LevelPrerequisite(10));
		AddPrerequisite(new CompletedPrerequisite("SOUT_Q_07"));

		AddObjective("kill0", "Kill 8 Red Kepa(s) or Jukopus(s) or Vubbe Thief(s) or Vubbe Scout(s)", new KillObjective(8, 400003, 400061, 11120, 57192));

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("Vis", 130));

		AddDialogHook("SIAULIAIOUT_MINER_C", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_MINER_C", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SOUT_Q_08_1", "SOUT_Q_08", "I'll defeat the monsters around", "Decline"))
		{
			case 1:
				dialog.HideNPC("SIAULIAIOUT_MINER_A");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("SOUT_Q_08_3");
		await dialog.Msg("FadeOutIN/400");
		dialog.HideNPC("SIAULIAIOUT_MINER_C");
		dialog.UnHideNPC("SIAULIAIOUT_MINER_A");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

