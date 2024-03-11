//--- Melia Script -----------------------------------------------------------
// Investigate Inner Wall District 8 (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Jore.
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

[QuestScript(30220)]
public class Quest30220Script : QuestScript
{
	protected override void Load()
	{
		SetId(30220);
		SetName("Investigate Inner Wall District 8 (1)");
		SetDescription("Talk to Kupole Jore");

		AddPrerequisite(new LevelPrerequisite(279));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_3_SQ_1"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11439));

		AddDialogHook("CASTLE_20_3_SQ_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_3_SQ_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE_20_3_SQ_2_select", "CASTLE_20_3_SQ_2", "Let's investigate together.", "About the Triple Layered Wall", "It would be a waste of time."))
		{
			case 1:
				await dialog.Msg("CASTLE_20_3_SQ_2_agree");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("CASTLE_20_3_SQ_2_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("CASTLE_20_3_SQ_2_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

