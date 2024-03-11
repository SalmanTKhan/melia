//--- Melia Script -----------------------------------------------------------
// No One Knows [Rogue Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Rogue Master.
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

[QuestScript(30041)]
public class Quest30041Script : QuestScript
{
	protected override void Load()
	{
		SetId(30041);
		SetName("No One Knows [Rogue Advancement]");
		SetDescription("Talk to the Rogue Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("MASTER_ROGUE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ROGUE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_ROGUE_6_1_select", "JOB_ROGUE_6_1", "I'll save it", "It seems hard"))
		{
			case 1:
				await dialog.Msg("JOB_ROGUE_6_1_agree");
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

		await dialog.Msg("JOB_ROGUE_6_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

