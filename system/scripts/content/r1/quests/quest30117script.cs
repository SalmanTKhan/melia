//--- Melia Script -----------------------------------------------------------
// The Power Imbued In The Curse [Featherfoot Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Featherfoot Master.
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

[QuestScript(30117)]
public class Quest30117Script : QuestScript
{
	protected override void Load()
	{
		SetId(30117);
		SetName("The Power Imbued In The Curse [Featherfoot Advancement]");
		SetDescription("Talk with the Featherfoot Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("FEATHERFOOT_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("FEATHERFOOT_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_FEATHERFOOT_7_1_select", "JOB_FEATHERFOOT_7_1", "Teach me", "You better back off"))
		{
			case 1:
				await dialog.Msg("JOB_FEATHERFOOT_7_1_agree");
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

		await dialog.Msg("JOB_FEATHERFOOT_7_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

