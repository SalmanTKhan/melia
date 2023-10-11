//--- Melia Script -----------------------------------------------------------
// The Rescue (1)
//--- Description -----------------------------------------------------------
// Quest to Follow Rose into the Novaha Monastery.
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

[QuestScript(50117)]
public class Quest50117Script : QuestScript
{
	protected override void Load()
	{
		SetId(50117);
		SetName("The Rescue (1)");
		SetDescription("Follow Rose into the Novaha Monastery");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_3_MQ050"));

		AddDialogHook("ABBEY641_ROZE01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY641_ROZE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_1_MQ010_startnpc01", "ABBAY_64_1_MQ010", "I'll ask the villagers on the other side of the door", "Let's find another solution"))
		{
			case 1:
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


		return HookResult.Break;
	}
}

