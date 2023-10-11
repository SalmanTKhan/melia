//--- Melia Script -----------------------------------------------------------
// In Secret [Shinobi Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Shinobi Master..
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

[QuestScript(30123)]
public class Quest30123Script : QuestScript
{
	protected override void Load()
	{
		SetId(30123);
		SetName("In Secret [Shinobi Advancement]");
		SetDescription("Talk with the Shinobi Master.");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("SHINOBI_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("SHINOBI_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SHINOBI_7_1_select", "JOB_SHINOBI_7_1", "I can do anything", "I will think about it for a moment"))
		{
			case 1:
				await dialog.Msg("JOB_SHINOBI_7_1_agree");
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

		await dialog.Msg("JOB_SHINOBI_7_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

