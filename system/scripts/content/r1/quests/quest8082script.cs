//--- Melia Script -----------------------------------------------------------
// To the Mines
//--- Description -----------------------------------------------------------
// Quest to Talk to Vaidotas.
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

[QuestScript(8082)]
public class Quest8082Script : QuestScript
{
	protected override void Load()
	{
		SetId(8082);
		SetName("To the Mines");
		SetDescription("Talk to Vaidotas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAU_OUT_Q16_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(11));
		AddPrerequisite(new CompletedPrerequisite("SOUT_Q_14"));

		AddObjective("kill0", "Kill 9 Vubbe Miner(s) or Vubbe Archer(s)", new KillObjective(9, 106000, 57266));

		AddReward(new ExpReward(10372, 10372));
		AddReward(new ItemReward("Vis", 1573));
		AddReward(new ItemReward("Scroll_Warp_quest", 10));

		AddDialogHook("SIAULIAIOUT_ALCHE_A", "BeforeStart", BeforeStart);
		AddDialogHook("MINE_1_ALCHEMIST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SOUT_Q_16_1", "SOUT_Q_16", "I'm ready to destroy the wagons", "I'm not yet prepared"))
		{
			case 1:
				dialog.UnHideNPC("SOUT_Q_16_WALL");
				dialog.UnHideNPC("SIAULIAIOUT_CART");
				dialog.UnHideNPC("SIAULIAIOUT_HIDD");
				dialog.UnHideNPC("SIAULIAIOUT_BLOCK");
				await dialog.Msg("SOUT_Q_16_1_AC");
				dialog.ShowHelp("TUTO_REIN");
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

		dialog.HideNPC("SIAULIAIOUT_CART");
		dialog.UnHideNPC("MINE_1_ALCHEMIST");
		dialog.HideNPC("SIAULIAIOUT_HIDD");
		dialog.HideNPC("SOUT_Q_16_WALL");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

