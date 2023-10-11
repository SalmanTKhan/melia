//--- Melia Script -----------------------------------------------------------
// Appease the Divine Spirit
//--- Description -----------------------------------------------------------
// Quest to Talk to Miko Master.
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

[QuestScript(50289)]
public class Quest50289Script : QuestScript
{
	protected override void Load()
	{
		SetId(50289);
		SetName("Appease the Divine Spirit");
		SetDescription("Talk to Miko Master");

		AddPrerequisite(new LevelPrerequisite(103));

		AddDialogHook("MIKO_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("MIKO_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATHEDRAL1_HQ1_start1", "CATHEDRAL1_HQ1", "I can try and appease the spirit for you.", "Why don't you do it yourself?"))
		{
			case 1:
				await dialog.Msg("CATHEDRAL1_HQ1_agree1");
				await dialog.Msg("CATHEDRAL1_HQ1_agree2");
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

		await dialog.Msg("CATHEDRAL1_HQ1_succ1");
		// Func/CATHEDRAL1_HIDDENQ1_COMP;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

