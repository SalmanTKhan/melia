//--- Melia Script -----------------------------------------------------------
// For the Church [Paladin Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Paladin Master.
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

[QuestScript(17480)]
public class Quest17480Script : QuestScript
{
	protected override void Load()
	{
		SetId(17480);
		SetName("For the Church [Paladin Advancement]");
		SetDescription("Meet the Paladin Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_PALADIN4_1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Paladin Master", new KillObjective(1, MonsterId.Npc_Paladinmaster));

		AddDialogHook("GELE573_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("GELE573_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_PALADIN4_1_ST", "JOB_PALADIN4_1", "Accept the duel with the Master", "Avoid the duel"))
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

		await dialog.Msg("JOB_PALADIN4_1_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

