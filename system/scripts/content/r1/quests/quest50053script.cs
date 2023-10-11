//--- Melia Script -----------------------------------------------------------
// Discarding Blind Shells (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sapper Master.
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

[QuestScript(50053)]
public class Quest50053Script : QuestScript
{
	protected override void Load()
	{
		SetId(50053);
		SetName("Discarding Blind Shells (1)");
		SetDescription("Talk to the Sapper Master");

		AddPrerequisite(new LevelPrerequisite(200));
		AddPrerequisite(new ItemPrerequisite("UNDERFORTRESS65_SQ010_BOOM", 1));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 7000));

		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDERFORTRESS_65_SQ010_startnpc", "UNDERFORTRESS_65_SQ010", "Hand over the unexploded bombs", "Just go"))
		{
			case 1:
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

		await dialog.Msg("UNDERFORTRESS_65_SQ010_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

