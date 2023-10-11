//--- Melia Script -----------------------------------------------------------
// Support of Rearguard Troops
//--- Description -----------------------------------------------------------
// Quest to Talk to Officer Danus.
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

[QuestScript(8200)]
public class Quest8200Script : QuestScript
{
	protected override void Load()
	{
		SetId(8200);
		SetName("Support of Rearguard Troops");
		SetDescription("Talk to Officer Danus");

		AddPrerequisite(new LevelPrerequisite(114));

		AddObjective("kill0", "Kill 8 Blue Puragi(s) or Bite(s) or Red Fisherman(s) or Big Blue Griba(s)", new KillObjective(8, 400302, 400281, 400344, 400462));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2736));

		AddDialogHook("KATYN14_LAIMUNAS", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN14_LAIMUNAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN14_MQ_00_01", "KATYN14_MQ_00", "I will lessen the monsters around", "About the Forest Road", "Sorry but I can't help you"))
		{
			case 1:
				await dialog.Msg("KATYN14_MQ_00_Q");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("KATYN14_MQ_00_21");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("KATYN14_MQ_00_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

