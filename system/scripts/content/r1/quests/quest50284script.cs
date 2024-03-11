//--- Melia Script -----------------------------------------------------------
// The Chaplain Master's Errand
//--- Description -----------------------------------------------------------
// Quest to Talk to the Chaplain Master.
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

[QuestScript(50284)]
public class Quest50284Script : QuestScript
{
	protected override void Load()
	{
		SetId(50284);
		SetName("The Chaplain Master's Errand");
		SetDescription("Talk to the Chaplain Master");

		AddPrerequisite(new LevelPrerequisite(120));

		AddDialogHook("CHAPLAIN_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPLAIN_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN22_HQ1_start1", "THORN22_HQ1", "I can go get the holy powder myself.", "This looks like a job for somebody else."))
		{
			case 1:
				await dialog.Msg("THORN22_HQ1_agree1");
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

		await dialog.Msg("THORN22_HQ1_succ1");
		// Func/SCR_THORN22_HIDDENQ1_COMP;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

