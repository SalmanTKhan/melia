//--- Melia Script -----------------------------------------------------------
// Mine Manager Brinker's Dedication (1)
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

[QuestScript(8073)]
public class Quest8073Script : QuestScript
{
	protected override void Load()
	{
		SetId(8073);
		SetName("Mine Manager Brinker's Dedication (1)");
		SetDescription("Talk to Mine Manager Brinker");

		AddPrerequisite(new LevelPrerequisite(10));

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("Vis", 130));

		AddDialogHook("SIAULIAIOUT_MINER_B", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_MINER_B", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SOUT_Q_07_1", "SOUT_Q_07", "I'll gather some stones for it", "Better run away quickly"))
		{
			case 1:
				dialog.UnHideNPC("SIAULIAIOUT_STONE");
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

		await dialog.Msg("SOUT_Q_07_3");
		await dialog.Msg("FadeOutIN/1100");
		dialog.UnHideNPC("SIAULIAIOUT_MINER_C");
		dialog.HideNPC("SIAULIAIOUT_MINER_B");
		dialog.HideNPC("SIAULIAIOUT_STONE");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SOUT_Q_08");
	}
}

