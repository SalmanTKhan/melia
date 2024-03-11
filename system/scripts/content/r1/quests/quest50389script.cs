//--- Melia Script -----------------------------------------------------------
// The Feline Post Town Case (3)
//--- Description -----------------------------------------------------------
// Quest to Check the Resident Logs.
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

[QuestScript(50389)]
public class Quest50389Script : QuestScript
{
	protected override void Load()
	{
		SetId(50389);
		SetName("The Feline Post Town Case (3)");
		SetDescription("Check the Resident Logs");

		AddPrerequisite(new LevelPrerequisite(384));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_2_SQ_02"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 22500));

		AddDialogHook("NICO812_SUBQ_NPC4", "BeforeStart", BeforeStart);
		AddDialogHook("NICO812_SUBQ_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("NICOPOLIS812_SQ03_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.Msg("BalloonText/NICO812_SUBQ3_MSG1/7");
	}
}

