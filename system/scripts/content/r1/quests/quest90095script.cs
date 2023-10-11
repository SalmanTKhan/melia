//--- Melia Script -----------------------------------------------------------
// Extremely Humanly
//--- Description -----------------------------------------------------------
// Quest to Talk to Refugee Hilda.
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

[QuestScript(90095)]
public class Quest90095Script : QuestScript
{
	protected override void Load()
	{
		SetId(90095);
		SetName("Extremely Humanly");
		SetDescription("Talk to Refugee Hilda");

		AddPrerequisite(new LevelPrerequisite(289));

		AddDialogHook("MAPLE_25_3_HILDA", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_3_HILDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_3_SQ_10_ST", "MAPLE_25_3_SQ_10", "I'll solve it.", "That seems difficult"))
		{
			case 1:
				await dialog.Msg("MAPLE_25_3_SQ_10_AG");
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

		dialog.HideNPC("MAPLE_25_3_HILDA");
		await dialog.Msg("FadeOutIN/3000");
		dialog.UnHideNPC("MAPLE_25_3_LINA");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Hilda is back.{nl}Return to the Kupoles.");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

