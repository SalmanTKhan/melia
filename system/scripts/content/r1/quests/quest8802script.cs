//--- Melia Script -----------------------------------------------------------
// Petrifying Frost Forecast (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Royal Army Guard Retia.
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

[QuestScript(8802)]
public class Quest8802Script : QuestScript
{
	protected override void Load()
	{
		SetId(8802);
		SetName("Petrifying Frost Forecast (1)");
		SetDescription("Talk to Royal Army Guard Retia");

		AddPrerequisite(new LevelPrerequisite(184));

		AddReward(new ExpReward(1046670, 1046670));
		AddReward(new ItemReward("expCard9", 1));
		AddReward(new ItemReward("Vis", 5704));

		AddDialogHook("FLASH59_RETIA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH59_RETIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH59_SQ_03_01", "FLASH59_SQ_03", "I will check it", "About the curse of the Petrifying Frost", "Tell him that there's no reason for you to help"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH59_SQ_03_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH59_SQ_03_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

