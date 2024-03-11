//--- Melia Script -----------------------------------------------------------
// Monster Colony (2)
//--- Description -----------------------------------------------------------
// Quest to Destroy the Monster Nest in Bonan Forest Road.
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

[QuestScript(60098)]
public class Quest60098Script : QuestScript
{
	protected override void Load()
	{
		SetId(60098);
		SetName("Monster Colony (2)");
		SetDescription("Destroy the Monster Nest in Bonan Forest Road");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAU15RE_SQ_05_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAU15RE_SQ_04"));

		AddObjective("kill0", "Kill 1 Chafer", new KillObjective(1, MonsterId.Boss_Chafer_Q4));

		AddReward(new ExpReward(1500, 1500));
		AddReward(new ItemReward("expCard1", 3));
		AddReward(new ItemReward("Vis", 104));

		AddDialogHook("SIAU15RE_SQ_05_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI15RE_RIGITESS", "BeforeEnd", BeforeEnd);
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


		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.UnHideNPC("SIAU15RE_SQ_05_NPC");
	}
}

