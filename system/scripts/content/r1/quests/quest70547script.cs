//--- Melia Script -----------------------------------------------------------
// What he did then
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim George.
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

[QuestScript(70547)]
public class Quest70547Script : QuestScript
{
	protected override void Load()
	{
		SetId(70547);
		SetName("What he did then");
		SetDescription("Talk to Pilgrim George");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_4_SQ02"));

		AddDialogHook("PILGRIM414_SQ_08", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM414_SQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM414_SQ_08_start", "PILGRIM41_4_SQ08"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("PILGRIM414_SQ_08_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

