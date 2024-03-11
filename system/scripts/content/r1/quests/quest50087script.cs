//--- Melia Script -----------------------------------------------------------
// Order to Retreat
//--- Description -----------------------------------------------------------
// Quest to Talk with the Ruklys Army Soldier's Spirit.
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

[QuestScript(50087)]
public class Quest50087Script : QuestScript
{
	protected override void Load()
	{
		SetId(50087);
		SetName("Order to Retreat");
		SetDescription("Talk with the Ruklys Army Soldier's Spirit");

		AddPrerequisite(new LevelPrerequisite(214));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 7490));

		AddDialogHook("UNDER69_SQ030_GHOST", "BeforeStart", BeforeStart);
		AddDialogHook("UNDER69_SQ030_GHOST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDER_69_SQ030_startnpc01", "UNDERFORTRESS_69_SQ030", "Alright, I'll help you", "Tell her to get rid of them on their own"))
		{
			case 1:
				await dialog.Msg("UNDER_69_SQ030_prog01");
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

		await dialog.Msg("UNDER_69_SQ030_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

