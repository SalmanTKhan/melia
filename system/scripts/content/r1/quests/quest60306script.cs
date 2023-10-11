//--- Melia Script -----------------------------------------------------------
// The Fugitive's Dream (9)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Grisia.
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

[QuestScript(60306)]
public class Quest60306Script : QuestScript
{
	protected override void Load()
	{
		SetId(60306);
		SetName("The Fugitive's Dream (9)");
		SetDescription("Talk to Kupole Grisia");

		AddPrerequisite(new LevelPrerequisite(378));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL107_SQ_8"));

		AddDialogHook("DCAPITAL107_GRISIA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL107_BLAD_NPC_4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL107_SQ_9_1", "DCAPITAL107_SQ_9", "You should rest.", "That's very cruel."))
		{
			case 1:
				// Func/SCR_DCAPITAL107_SUBQ9;
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

		await dialog.Msg("DCAPITAL107_SQ_9_3");
		await dialog.Msg("FadeOutIN/1500");
		dialog.HideNPC("DCAPITAL107_GRISIA_NPC_1");
		await dialog.Msg("DCAPITAL107_SQ_9_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

