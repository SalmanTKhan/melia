//--- Melia Script -----------------------------------------------------------
// Duties of Newbies
//--- Description -----------------------------------------------------------
// Quest to Talk to Gerda.
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

[QuestScript(41620)]
public class Quest41620Script : QuestScript
{
	protected override void Load()
	{
		SetId(41620);
		SetName("Duties of Newbies");
		SetDescription("Talk to Gerda");

		AddPrerequisite(new LevelPrerequisite(110));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM_48_SQ_010"));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2640));

		AddDialogHook("PILGRIM_48_GERDA", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_48_GERDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM_48_SQ_020_ST", "PILGRIM_48_SQ_020", "I will help secretly", "Cheer up"))
		{
			case 1:
				await dialog.Msg("PILGRIM_48_SQ_020_AG");
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

		await dialog.Msg("PILGRIM_48_SQ_020_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

