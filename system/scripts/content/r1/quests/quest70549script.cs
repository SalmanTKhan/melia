//--- Melia Script -----------------------------------------------------------
// Resolving conflicts
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Dorma.
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

[QuestScript(70549)]
public class Quest70549Script : QuestScript
{
	protected override void Load()
	{
		SetId(70549);
		SetName("Resolving conflicts");
		SetDescription("Talk to Monk Dorma");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_4_SQ02"));

		AddDialogHook("PILGRIM414_SQ_02_1", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM414_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM414_SQ_10_start", "PILGRIM41_4_SQ10"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("PILGRIM414_SQ_10_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

