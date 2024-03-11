//--- Melia Script -----------------------------------------------------------
// Perfect Holy water [Cleric Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cleric Master.
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

[QuestScript(1116)]
public class Quest1116Script : QuestScript
{
	protected override void Load()
	{
		SetId(1116);
		SetName("Perfect Holy water [Cleric Advancement] (2)");
		SetDescription("Talk to the Cleric Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_CLERIC2_2_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("JOB_CLERIC2_1"));

		AddDialogHook("MASTER_CLERIC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CLERIC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		dialog.HideNPC("JOB_CLERIC2_2_NPC");
		await dialog.Msg("JOB_CLERIC2_2_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.UnHideNPC("JOB_CLERIC2_2_NPC");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Cure the patient in Siauliai Miners' Village!");
	}
}

