//--- Melia Script -----------------------------------------------------------
// An Unowned Object
//--- Description -----------------------------------------------------------
// Quest to Talk with Settler Ivanayus.
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

[QuestScript(60081)]
public class Quest60081Script : QuestScript
{
	protected override void Load()
	{
		SetId(60081);
		SetName("An Unowned Object");
		SetDescription("Talk with Settler Ivanayus");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("expCard1", 2));
		AddReward(new ItemReward("Vis", 13));

		AddDialogHook("SIAULIAI16_IHBANAYUS", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI16_IHBANAYUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU16_SQ_05_01", "SIAU16_SQ_05", "I'll see what I can find", "Some things can't be helped"))
		{
			case 1:
				dialog.UnHideNPC("SIAU16_SQ_05_NPC");
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

