//--- Melia Script -----------------------------------------------------------
// Unshakable Faith [Krivis Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Krivis Master.
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

[QuestScript(1147)]
public class Quest1147Script : QuestScript
{
	protected override void Load()
	{
		SetId(1147);
		SetName("Unshakable Faith [Krivis Advancement]");
		SetDescription("Talk to the Krivis Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_KRIVI3_1_TRACK", 3000);

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("kill0", "Kill 1 Krivis Master", new KillObjective(1, MonsterId.Npc_KRV_Master));

		AddDialogHook("MASTER_KRIWI", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_KRIWI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_KRIVI3_1_select1", "JOB_KRIVI3_1", "I'll prove myself through a duel", "Avoid the duel"))
		{
			case 1:
				await dialog.Msg("JOB_KRIVI3_1_agree1");
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

		await dialog.Msg("JOB_KRIVI3_1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

