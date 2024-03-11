//--- Melia Script -----------------------------------------------------------
// Showing True Colors(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Clark.
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

[QuestScript(70526)]
public class Quest70526Script : QuestScript
{
	protected override void Load()
	{
		SetId(70526);
		SetName("Showing True Colors(1)");
		SetDescription("Talk to Believer Clark");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM41_2_SQ07_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(261));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_2_SQ06"));

		AddObjective("kill0", "Kill 1 Green Minos", new KillObjective(1, MonsterId.Minos_Green_Event));
		AddObjective("kill1", "Kill 4 Red Guardian Spider(s)", new KillObjective(4, MonsterId.Defender_Spider_Red));

		AddDialogHook("PILGRIM412_SQ_05", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM412_SQ_07_start", "PILGRIM41_2_SQ07", "Say that you will do that", "Say that you do not wish to interfere with the Order's business"))
		{
			case 1:
				// Func/SCR_PILGRIM412_SQ_07_P;
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

