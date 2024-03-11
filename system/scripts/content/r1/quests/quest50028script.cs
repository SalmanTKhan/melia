//--- Melia Script -----------------------------------------------------------
// The Remaining Danger (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Vaidotas.
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

[QuestScript(50028)]
public class Quest50028Script : QuestScript
{
	protected override void Load()
	{
		SetId(50028);
		SetName("The Remaining Danger (1)");
		SetDescription("Talk to Vaidotas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PARTY_Q_010_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(100));

		AddDialogHook("SIAULIAIOUT_ALCHE_A", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_ALCHE_A", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PARTY_Q_010_startnpc01", "PARTY_Q_010", "I will check it", "I don't have time for that now"))
		{
			case 1:
				await dialog.Msg("PARTY_Q_010_AG");
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

		await dialog.Msg("PARTY_Q_010_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

