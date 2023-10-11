//--- Melia Script -----------------------------------------------------------
// Alongside Assisters(4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Geraldasia.
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

[QuestScript(91005)]
public class Quest91005Script : QuestScript
{
	protected override void Load()
	{
		SetId(91005);
		SetName("Alongside Assisters(4)");
		SetDescription("Talk to Geraldasia");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ASSISTOR_TUTO_TRACK_01", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(100));
		AddPrerequisite(new CompletedPrerequisite("ASSISTOR_TUTO_03"));

		AddDialogHook("NPC_JUNK_SHOP_KLAPEDA", "BeforeStart", BeforeStart);
		AddDialogHook("NPC_JUNK_SHOP_KLAPEDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ASSISTOR_TUTO_DLG_12", "ASSISTOR_TUTO_04", "I'll look into this.", "I don't have time for it."))
		{
			case 1:
				await dialog.Msg("ASSISTOR_TUTO_DLG_13");
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

		// Func/TrackInTrack/SCR_ASSISTOR_TUTO_TRACK_01_IN_01;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

