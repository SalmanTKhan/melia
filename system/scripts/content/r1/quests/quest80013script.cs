//--- Melia Script -----------------------------------------------------------
// Carlyle's Test (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Carlyle's Spirit.
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

[QuestScript(80013)]
public class Quest80013Script : QuestScript
{
	protected override void Load()
	{
		SetId(80013);
		SetName("Carlyle's Test (1)");
		SetDescription("Talk to Carlyle's Spirit");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CATACOMB_33_2_SQ_06_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_2_SQ_05"));

		AddObjective("kill0", "Kill 1 Sanctum Object", new KillObjective(1, MonsterId.Npc_Pilgrim_Shrine));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1406));

		AddDialogHook("CATACOMB_33_2_KARLYLE", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_33_2_KARLYLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_33_2_SQ_06_start", "CATACOMB_33_2_SQ_06", "I am in search of the Order of the Tree of Truth's conspiracy", "Ignore"))
		{
			case 1:
				await dialog.Msg("CATACOMB_33_2_SQ_06_agree");
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


		return HookResult.Break;
	}
}

