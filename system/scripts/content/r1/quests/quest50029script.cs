//--- Melia Script -----------------------------------------------------------
// The Remaining Danger (2)
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

[QuestScript(50029)]
public class Quest50029Script : QuestScript
{
	protected override void Load()
	{
		SetId(50029);
		SetName("The Remaining Danger (2)");
		SetDescription("Talk to Vaidotas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PARTY_Q_011_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(100));
		AddPrerequisite(new CompletedPrerequisite("PARTY_Q_010"));

		AddDialogHook("SIAULIAIOUT_ALCHE_A", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_ALCHE_A", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PARTY_Q_011_startnpc01", "PARTY_Q_011", "I will put the incense burner", "I can only help so much"))
		{
			case 1:
				dialog.UnHideNPC("PARTY_Q_011_CHAMICAL01");
				// Func/PARTY_Q_011_RESTART;
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

		await dialog.Msg("PARTY_Q_011_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

