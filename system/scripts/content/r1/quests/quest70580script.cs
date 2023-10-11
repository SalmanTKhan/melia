//--- Melia Script -----------------------------------------------------------
// What Suppresses the Divine Power
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70580)]
public class Quest70580Script : QuestScript
{
	protected override void Load()
	{
		SetId(70580);
		SetName("What Suppresses the Divine Power");
		SetDescription("Talk to Monk Stella");

		AddPrerequisite(new LevelPrerequisite(271));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_3_SQ08"));

		AddDialogHook("PILGRIM415_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM415_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM415_SQ_01_start", "PILGRIM41_5_SQ01", "Ask where you need to go", "Decline the small tasks"))
		{
			case 1:
				await dialog.Msg("PILGRIM415_SQ_01_agree");
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

		await dialog.Msg("PILGRIM415_SQ_01_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

