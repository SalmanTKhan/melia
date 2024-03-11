//--- Melia Script -----------------------------------------------------------
// Retaking the Abbey
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70561)]
public class Quest70561Script : QuestScript
{
	protected override void Load()
	{
		SetId(70561);
		SetName("Retaking the Abbey");
		SetDescription("Talk to Monk Stella");

		AddPrerequisite(new LevelPrerequisite(268));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_3_SQ01"));

		AddDialogHook("PILGRIM413_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM413_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM413_SQ_02_start", "PILGRIM41_3_SQ02"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("PILGRIM413_SQ_02_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

