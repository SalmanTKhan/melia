//--- Melia Script -----------------------------------------------------------
// Preparing for Battle (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Callans.
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

[QuestScript(50152)]
public class Quest50152Script : QuestScript
{
	protected override void Load()
	{
		SetId(50152);
		SetName("Preparing for Battle (4)");
		SetDescription("Talk to Soldier Callans");

		AddPrerequisite(new LevelPrerequisite(238));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_70_SQ6"));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 8568));

		AddDialogHook("TABLE70_SOLDIER3_1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE70_SOLDIER3_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_70_SQ7_startnpc01", "TABLELAND_70_SQ7", "What can I help you with?", "I'll wait until the job is finished"))
		{
			case 1:
				await dialog.Msg("TABLELAND_70_SQ7_startnpc02");
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

		await dialog.Msg("TABLELAND_70_SQ7_succ01");
		// Func/TABLELAND70_SUBQ7_COMPLETE;
		await dialog.Msg("TABLELAND_70_SQ7_succ02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

