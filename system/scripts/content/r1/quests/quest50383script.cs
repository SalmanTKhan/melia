//--- Melia Script -----------------------------------------------------------
// Starry Stairs
//--- Description -----------------------------------------------------------
// Quest to Talk to Ramute.
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

[QuestScript(50383)]
public class Quest50383Script : QuestScript
{
	protected override void Load()
	{
		SetId(50383);
		SetName("Starry Stairs");
		SetDescription("Talk to Ramute");

		AddPrerequisite(new LevelPrerequisite(381));

		AddReward(new ItemReward("Vis", 19000));

		AddDialogHook("NICO811_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("NICO811_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICO811_SUBQ5_START", "F_NICOPOLIS_81_1_SQ_05", "I'll collect them for you.", "Give up already."))
		{
			case 1:
				await dialog.Msg("NICO811_SUBQ5_AGREE1");
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

		await dialog.Msg("NICO811_SUBQ5_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

