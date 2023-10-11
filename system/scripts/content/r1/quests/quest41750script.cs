//--- Melia Script -----------------------------------------------------------
// Lost Symbol (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kestas.
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

[QuestScript(41750)]
public class Quest41750Script : QuestScript
{
	protected override void Load()
	{
		SetId(41750);
		SetName("Lost Symbol (2)");
		SetDescription("Talk to Kestas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM_49_SQ_060_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(113));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_49_SQ_050"));

		AddObjective("kill0", "Kill 9 Vekarabe(s) or Orange Dandel(s) or Kepari Shaman(s)", new KillObjective(9, 58131, 58132, 58133));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("PILGRIM_49_KESTAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_49_KESTAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_49_SQ_060_ST", "PILGRIM_49_SQ_060", "Farewell", "Wait for a while"))
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

		await dialog.Msg("PILGRIM_49_SQ_060_COMP");
		await Task.Delay(1000);
		dialog.HideNPC("PILGRIM_49_KESTAS");
		await dialog.Msg("FadeOutIN/2500");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

