//--- Melia Script -----------------------------------------------------------
// The Missing Girl (1)
//--- Description -----------------------------------------------------------
// Quest to Find the traces of the Mysterious Girl.
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

[QuestScript(80031)]
public class Quest80031Script : QuestScript
{
	protected override void Load()
	{
		SetId(80031);
		SetName("The Missing Girl (1)");
		SetDescription("Find the traces of the Mysterious Girl");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ORCHARD_342_MQ_03_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_342_MQ_02"));

		AddObjective("kill0", "Kill 10 Ferret(s) or Ferret Loader(s)", new KillObjective(10, 57850, 57851));

		AddReward(new ExpReward(368565, 368565));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1920));

		AddDialogHook("ORCHARD342_LEJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORCHARD_342_MQ_04");
	}
}

