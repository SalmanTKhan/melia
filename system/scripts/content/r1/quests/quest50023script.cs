//--- Melia Script -----------------------------------------------------------
// Louise's Farmland (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Louise.
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

[QuestScript(50023)]
public class Quest50023Script : QuestScript
{
	protected override void Load()
	{
		SetId(50023);
		SetName("Louise's Farmland (3)");
		SetDescription("Talk to Louise");

		AddPrerequisite(new LevelPrerequisite(70));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_50_1_SQ_140"));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1330));

		AddDialogHook("SIAULIAI_50_1_SQ_MAN01", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_50_1_SQ_MAN01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_50_1_SQ_160_select01", "SIAULIAI_50_1_SQ_160", "I'll help you", "Decline"))
		{
			case 1:
				dialog.UnHideNPC("SIAULIAI50_FENCE_BUILD01");
				dialog.UnHideNPC("SIAULIAI50_FENCE_BUILD02");
				dialog.UnHideNPC("SIAULIAI50_FENCE_BUILD03");
				dialog.UnHideNPC("SIAULIAI50_FENCE_BUILD04");
				dialog.UnHideNPC("SIAULIAI50_FENCE_BUILD05");
				dialog.UnHideNPC("SIAULIAI50_FENCE_BUILD06");
				dialog.UnHideNPC("SIAULIAI50_FENCE_BUILD07");
				dialog.UnHideNPC("SIAULIAI50_FENCE_BUILD08");
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

		await dialog.Msg("SIAULIAI_50_1_SQ_160_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

