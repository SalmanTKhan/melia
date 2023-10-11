//--- Melia Script -----------------------------------------------------------
// Worrisome Disappearances
//--- Description -----------------------------------------------------------
// Quest to Talk to Mercenary Glen.
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

[QuestScript(4418)]
public class Quest4418Script : QuestScript
{
	protected override void Load()
	{
		SetId(4418);
		SetName("Worrisome Disappearances");
		SetDescription("Talk to Mercenary Glen");

		AddPrerequisite(new LevelPrerequisite(67));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1273));

		AddDialogHook("ROKAS27_GLEN", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS27_GLEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS27_QB_6_select1", "ROKAS27_QB_6", "I'll gather some clues by defeating Sauga", "About the disappearances", "Decline"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("ROKAS27_QB_6_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("ROKAS27_QB_6_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

