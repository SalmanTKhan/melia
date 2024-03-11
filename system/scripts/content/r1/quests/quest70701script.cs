//--- Melia Script -----------------------------------------------------------
// Find Out Yourself
//--- Description -----------------------------------------------------------
// Quest to Talk to the Soul of Hayatin.
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

[QuestScript(70701)]
public class Quest70701Script : QuestScript
{
	protected override void Load()
	{
		SetId(70701);
		SetName("Find Out Yourself");
		SetDescription("Talk to the Soul of Hayatin");

		AddPrerequisite(new LevelPrerequisite(278));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN42_1_SQ01"));

		AddDialogHook("BRACKEN421_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN421_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN421_SQ_02_start", "BRACKEN42_1_SQ02", "Tell me what happened and I will help you.", "Just go to the eternal slumber already."))
		{
			case 1:
				await dialog.Msg("BRACKEN421_SQ_02_AG");
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

		await dialog.Msg("BRACKEN421_SQ_02_succ");
		// Func/SCR_BRACKEN421_SQ_02_SUCCESS;
		await Task.Delay(1000);
		await dialog.Msg("FadeOutIN/1000");
		dialog.UnHideNPC("BRACKEN421_SQ_01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

