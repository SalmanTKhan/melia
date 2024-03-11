//--- Melia Script -----------------------------------------------------------
// To Restore the Honor of the Hero
//--- Description -----------------------------------------------------------
// Quest to Talk to the soul of Victoras.
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

[QuestScript(70709)]
public class Quest70709Script : QuestScript
{
	protected override void Load()
	{
		SetId(70709);
		SetName("To Restore the Honor of the Hero");
		SetDescription("Talk to the soul of Victoras");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "BRACKEN42_1_SQ10_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(278));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN42_1_SQ09"));

		AddDialogHook("BRACKEN421_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("JOURNEY_SHOP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN421_SQ_10_start", "BRACKEN42_1_SQ10"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("BRACKEN421_SQ_10_succ1");
		await dialog.Msg("FadeOutIN/1000");
		await dialog.Msg("BRACKEN421_SQ_10_succ2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

