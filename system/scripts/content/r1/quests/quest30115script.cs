//--- Melia Script -----------------------------------------------------------
// Basic Leadership [Templar Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to Knight Commander Uska.
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

[QuestScript(30115)]
public class Quest30115Script : QuestScript
{
	protected override void Load()
	{
		SetId(30115);
		SetName("Basic Leadership [Templar Advancement]");
		SetDescription("Talk to Knight Commander Uska");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("KLAPEDA_USKA", "BeforeStart", BeforeStart);
		AddDialogHook("KLAPEDA_USKA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_TEMPLAR_7_1_select", "JOB_TEMPLAR_7_1", "I am confident", "It seems too hard"))
		{
			case 1:
				await dialog.Msg("JOB_TEMPLAR_7_1_agree");
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

		await dialog.Msg("JOB_TEMPLAR_7_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

