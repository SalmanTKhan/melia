//--- Melia Script -----------------------------------------------------------
// My Precious Friend (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Companion Trader Toras.
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

[QuestScript(50264)]
public class Quest50264Script : QuestScript
{
	protected override void Load()
	{
		SetId(50264);
		SetName("My Precious Friend (1)");
		SetDescription("Talk to Companion Trader Toras");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("ORSHA_HIDDENQ3_ITEM1", 1));

		AddDialogHook("ORSHA_PETSHOP", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORSHA_HQ2_start1", "ORSHA_HQ2", "How do you make the food?", "I'll do it later"))
		{
			case 1:
				await dialog.Msg("ORSHA_HQ2_agree1");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORSHA_HQ3");
	}
}

