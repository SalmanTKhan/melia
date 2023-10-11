//--- Melia Script -----------------------------------------------------------
// Expected Result
//--- Description -----------------------------------------------------------
// Quest to Talk to Investigator Horatio.
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

[QuestScript(70913)]
public class Quest70913Script : QuestScript
{
	protected override void Load()
	{
		SetId(70913);
		SetName("Expected Result");
		SetDescription("Talk to Investigator Horatio");

		AddPrerequisite(new LevelPrerequisite(303));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL103_SQ13"));

		AddReward(new ItemReward("DCAPITAL103_BOOK3", 1));

		AddDialogHook("DCAPITAL103_SQ_11", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL103_SQ_11", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL103_SQ_14_start", "DCAPITAL103_SQ14"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("DCAPITAL103_SQ_14_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

