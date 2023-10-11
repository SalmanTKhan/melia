//--- Melia Script -----------------------------------------------------------
// Where Did Everybody Go? (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Traveling Merchant Rose.
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

[QuestScript(50145)]
public class Quest50145Script : QuestScript
{
	protected override void Load()
	{
		SetId(50145);
		SetName("Where Did Everybody Go? (6)");
		SetDescription("Talk to Traveling Merchant Rose");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_2_MQ050"));

		AddDialogHook("BRACKEN632_ROZE03", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN632_ROZE03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN632_MQ060_startnpc01", "BRACKEN_63_2_MQ060", "Let's all help out", "Tell him that you need some time to think"))
		{
			case 1:
				await dialog.Msg("BRACKEN632_MQ060_startnpc_prog01");
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

