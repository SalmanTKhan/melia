//--- Melia Script -----------------------------------------------------------
// Passage Ritual of the Wind [Wugushi Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Wugushi Submaster.
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

[QuestScript(1153)]
public class Quest1153Script : QuestScript
{
	protected override void Load()
	{
		SetId(1153);
		SetName("Passage Ritual of the Wind [Wugushi Advancement]");
		SetDescription("Talk to the Wugushi Submaster");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_WUGU3_1_TRACK", 3000);

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("kill0", "Kill 1 Wugushi Submaster", new KillObjective(1, MonsterId.Npc_WUG_Sub_Master_Mon));

		AddReward(new ItemReward("Hat_628067", 1));

		AddDialogHook("JOB_WUGU3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_WUGU3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_WUGU3_1_select1", "JOB_WUGU3_1", "Accept the duel with the Master", "Avoid the duel"))
		{
			case 1:
				await dialog.Msg("JOB_WUGU3_1_agree1");
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

		await dialog.Msg("JOB_WUGU3_1_succ1");
		dialog.ShowHelp("TUTO_CLASS_WUGUSHI");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

