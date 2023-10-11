//--- Melia Script -----------------------------------------------------------
// Preparations for the Call (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Senior Monk Goss.
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

[QuestScript(70165)]
public class Quest70165Script : QuestScript
{
	protected override void Load()
	{
		SetId(70165);
		SetName("Preparations for the Call (1)");
		SetDescription("Talk to Senior Monk Goss");

		AddPrerequisite(new LevelPrerequisite(183));
		AddPrerequisite(new CompletedPrerequisite("ABBEY39_4_MQ05"));

		AddDialogHook("ABBEY394_MQ_06", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY394_MQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY39_4_MQ_06_1", "ABBEY39_4_MQ06", "I will find Moheim", "I'll take a break for a while."))
		{
			case 1:
				dialog.HideNPC("ABBEY394_MQ_06_1");
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

		await dialog.Msg("ABBEY39_4_MQ_06_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

