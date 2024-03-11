//--- Melia Script -----------------------------------------------------------
// Statue of Goddess Zemyna
//--- Description -----------------------------------------------------------
// Quest to Talk with Settler Dallanas.
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

[QuestScript(60082)]
public class Quest60082Script : QuestScript
{
	protected override void Load()
	{
		SetId(60082);
		SetName("Statue of Goddess Zemyna");
		SetDescription("Talk with Settler Dallanas");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("expCard1", 2));
		AddReward(new ItemReward("Vis", 13));

		AddDialogHook("SIAULIAI16_DALLANAS", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU16_SQ_06_01", "SIAU16_SQ_06", "I will take a look around", "Tell me about the missing goddesses", "I don't need that"))
		{
			case 1:
				dialog.ShowHelp("MINI_E_STATUE");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("SIAU16_SQ_06_01_add");
				break;
		}

		return HookResult.Break;
	}
}

