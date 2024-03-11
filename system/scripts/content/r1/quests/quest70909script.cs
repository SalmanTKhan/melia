//--- Melia Script -----------------------------------------------------------
// Token of Gratitude
//--- Description -----------------------------------------------------------
// Quest to Talk with Gasper.
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

[QuestScript(70909)]
public class Quest70909Script : QuestScript
{
	protected override void Load()
	{
		SetId(70909);
		SetName("Token of Gratitude");
		SetDescription("Talk with Gasper");

		AddPrerequisite(new LevelPrerequisite(303));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL103_SQ07"), new CompletedPrerequisite("DCAPITAL103_SQ08"), new CompletedPrerequisite("DCAPITAL103_SQ09"));

		AddReward(new ItemReward("DCAPITAL103_BOOK2", 1));

		AddDialogHook("DCAPITAL103_SQ_07", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL103_SQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL103_SQ_10_start", "DCAPITAL103_SQ10"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("DCAPITAL103_SQ_10_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

