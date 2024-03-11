//--- Melia Script -----------------------------------------------------------
// Lifting Suspicions
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Vados.
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

[QuestScript(70541)]
public class Quest70541Script : QuestScript
{
	protected override void Load()
	{
		SetId(70541);
		SetName("Lifting Suspicions");
		SetDescription("Talk to Pilgrim Vados");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_4_SQ01"));

		AddDialogHook("PILGRIM414_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM414_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM414_SQ_02_start", "PILGRIM41_4_SQ02", "Say that you will prove his innocence", "Say that you respect the judgement of the Pilgrims"))
		{
			case 1:
				await dialog.Msg("PILGRIM414_SQ_02_agree");
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

		await dialog.Msg("PILGRIM414_SQ_02_succ1");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("PILGRIM414_SQ_02");
		dialog.UnHideNPC("PILGRIM414_SQ_02_1");
		await dialog.Msg("PILGRIM414_SQ_02_succ2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

