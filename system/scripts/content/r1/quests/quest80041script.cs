//--- Melia Script -----------------------------------------------------------
// Divine Encounter 
//--- Description -----------------------------------------------------------
// Quest to Look for Goddess Lada.
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

[QuestScript(80041)]
public class Quest80041Script : QuestScript
{
	protected override void Load()
	{
		SetId(80041);
		SetName("Divine Encounter ");
		SetDescription("Look for Goddess Lada");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ORCHARD_324_MQ_01_TRACK", "m_boss_scenario2");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_342_MQ_08"));

		AddDialogHook("ORCHARD324_LADA", "BeforeEnd", BeforeEnd);
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
		// Func/ORCHARD324_BINDIG_UNHIDE;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORCHARD_324_MQ_02");
	}
}

