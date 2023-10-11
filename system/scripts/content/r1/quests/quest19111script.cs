//--- Melia Script -----------------------------------------------------------
// Open Sesame (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to unknown being.
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

[QuestScript(19111)]
public class Quest19111Script : QuestScript
{
	protected override void Load()
	{
		SetId(19111);
		SetName("Open Sesame (1)");
		SetDescription("Talk to unknown being");

		AddPrerequisite(new LevelPrerequisite(102));
		AddPrerequisite(new CompletedPrerequisite("CMINE6_TO_KATYN7_1"));

		AddDialogHook("KLAIPE_HQ_01_NPC_E", "BeforeStart", BeforeStart);
		AddDialogHook("KLAIPE_HQ_01_NPC_D", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KLAIPE_HQ_01_ST", "KLAIPE_HQ_01", "I'll find the clue so give me a hint", "Ignore"))
		{
			case 1:
				await dialog.Msg("KLAIPE_HQ_01_AC");
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

		await dialog.Msg("KLAIPE_HQ_01_COMP");
		// Func/DESTROY_SESSION_KLAIPE_HQ_01;
		dialog.UnHideNPC("KLAIPE_HQ_02_NPC");
		dialog.HideNPC("KLAIPE_HQ_01_NPC_E");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

