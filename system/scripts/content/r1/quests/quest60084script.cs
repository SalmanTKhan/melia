//--- Melia Script -----------------------------------------------------------
// The Settler Without Rest
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

[QuestScript(60084)]
public class Quest60084Script : QuestScript
{
	protected override void Load()
	{
		SetId(60084);
		SetName("The Settler Without Rest");
		SetDescription("Talk with Settler Dallanas");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("expCard1", 2));
		AddReward(new ItemReward("Vis", 13));

		AddDialogHook("SIAULIAI16_DALLANAS", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI16_DALLANAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU16_SQ_08_01", "SIAU16_SQ_08", "I will bring it", "It will come if you wait"))
		{
			case 1:
				dialog.UnHideNPC("SIAU16_SQ_08_NPC_1");
				dialog.UnHideNPC("SIAU16_SQ_08_NPC_2");
				dialog.UnHideNPC("SIAU16_SQ_08_NPC_3");
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


		return HookResult.Break;
	}
}

