//--- Melia Script -----------------------------------------------------------
// Material for Compiling A Scripture (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Giedra.
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

[QuestScript(41730)]
public class Quest41730Script : QuestScript
{
	protected override void Load()
	{
		SetId(41730);
		SetName("Material for Compiling A Scripture (2)");
		SetDescription("Talk to Giedra");

		AddPrerequisite(new LevelPrerequisite(113));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_49_SQ_030"));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("PILGRIM_49_GIEDRA", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_49_GIEDRA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_49_SQ_040_ST", "PILGRIM_49_SQ_040", "I can do it", "It's too difficult"))
		{
			case 1:
				await dialog.Msg("PILGRIM_49_SQ_040_AC");
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

		await dialog.Msg("PILGRIM_49_SQ_040_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

