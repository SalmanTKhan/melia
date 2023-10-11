//--- Melia Script -----------------------------------------------------------
// The Sculpture in Starry Town Square (1)
//--- Description -----------------------------------------------------------
// Quest to Use the Magic Block on the Sculptures in Starry Town Square.
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

[QuestScript(50385)]
public class Quest50385Script : QuestScript
{
	protected override void Load()
	{
		SetId(50385);
		SetName("The Sculpture in Starry Town Square (1)");
		SetDescription("Use the Magic Block on the Sculptures in Starry Town Square");

		AddPrerequisite(new LevelPrerequisite(381));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_1_SQ_02"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 20000));

		AddDialogHook("NICO811_DEVICE3", "BeforeStart", BeforeStart);
		AddDialogHook("NICO811_DEVICE3", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("BalloonText/NICO811_SUBQ221_MSGTXT2/5");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_NICOPOLIS_81_1_SQ_02_2");
	}
}

