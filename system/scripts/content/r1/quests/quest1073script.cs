//--- Melia Script -----------------------------------------------------------
// Rough Advancement [Barbarian Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Barbarian Master.
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

[QuestScript(1073)]
public class Quest1073Script : QuestScript
{
	protected override void Load()
	{
		SetId(1073);
		SetName("Rough Advancement [Barbarian Advancement]");
		SetDescription("Talk to the Barbarian Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_BARBARIAN2_TRACK", 3000);

		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("kill0", "Kill 1 Barbarian Master", new KillObjective(1, MonsterId.Npc_BAR_Master));

		AddDialogHook("JOB_BARBARIAN2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_BARBARIAN2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_BARBARIAN2_select1", "JOB_BARBARIAN2", "Accept the battle with the Master", "Avoid the battle"))
		{
			case 1:
				await dialog.Msg("JOB_BARBARIAN2_agree1");
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

		await dialog.Msg("JOB_BARBARIAN2_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

