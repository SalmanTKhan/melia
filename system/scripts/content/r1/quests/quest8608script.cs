//--- Melia Script -----------------------------------------------------------
// Obversion
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Alfonsas.
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

[QuestScript(8608)]
public class Quest8608Script : QuestScript
{
	protected override void Load()
	{
		SetId(8608);
		SetName("Obversion");
		SetDescription("Talk to Follower Alfonsas");

		AddPrerequisite(new LevelPrerequisite(35));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 490));

		AddDialogHook("GELE574_ADRIJA", "BeforeStart", BeforeStart);
		AddDialogHook("GELE574_ADRIJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE574_MQ_08_01", "GELE574_MQ_08", "That's a reasonable opinion", "Decline"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("GELE574_MQ_08_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

