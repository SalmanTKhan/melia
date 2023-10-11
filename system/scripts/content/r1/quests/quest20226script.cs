//--- Melia Script -----------------------------------------------------------
// Sacrifice (Infroburk)
//--- Description -----------------------------------------------------------
// Quest to Talk to Necromancer Drasius.
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

[QuestScript(20226)]
public class Quest20226Script : QuestScript
{
	protected override void Load()
	{
		SetId(20226);
		SetName("Sacrifice (Infroburk)");
		SetDescription("Talk to Necromancer Drasius");

		AddPrerequisite(new LevelPrerequisite(99));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1980));

		AddDialogHook("REMAIN38_SQ_DRASIUS", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN38_SQ_DRASIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN38_SQ04_select01", "REMAIN38_SQ04", "I'll bring the Infroburk", "That's going to be nasty. I don't want to."))
		{
			case 1:
				await dialog.Msg("REMAIN38_SQ04_AG");
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

		await dialog.Msg("REMAIN38_SQ04_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

