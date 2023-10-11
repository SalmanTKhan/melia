//--- Melia Script -----------------------------------------------------------
// Clue in Novaha
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Laima.
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

[QuestScript(91166)]
public class Quest91166Script : QuestScript
{
	protected override void Load()
	{
		SetId(91166);
		SetName("Clue in Novaha");
		SetDescription("Talk to Goddess Laima");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "EP15_1_F_ABBEY1_2_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(480));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY1_1"));

		AddDialogHook("NPC_LITTLEGIRL_01", "BeforeStart", BeforeStart);
		AddDialogHook("WARP_C_KLAIPE_CATHEDRAL_MEDIUM", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_1_F_ABBEY1_2_DLG1", "EP15_1_F_ABBEY1_2", "Tell me the answer.", "I need to be ready to hear it."))
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

		dialog.UnHideNPC("EP15_1_FABBEY1_AD1");
		dialog.UnHideNPC("EP15_1_FABBEY1_ROZE1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

