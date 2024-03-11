//--- Melia Script -----------------------------------------------------------
// Get Out of Bewilderment (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Witas.
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

[QuestScript(19911)]
public class Quest19911Script : QuestScript
{
	protected override void Load()
	{
		SetId(19911);
		SetName("Get Out of Bewilderment (5)");
		SetDescription("Talk to Pilgrim Witas");

		AddPrerequisite(new LevelPrerequisite(133));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM52_SQ_050"));

		AddDialogHook("PILGRIM52_NPC02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM52_NPC02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM52_SQ_051_ST", "PILGRIM52_SQ_051", "Listen quietly", "Leave your spot"))
		{
			case 1:
				await dialog.Msg("PILGRIM52_SQ_051_AC");
				await Task.Delay(500);
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Witas passed away.{nl}Please make his grave.");
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

		dialog.HideNPC("PILGRIM52_NPC02");
		await dialog.Msg("FadeOutIN/1000");
		dialog.UnHideNPC("PILGRIM52_NPC_TOMB");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You've made the grave for Witas");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

