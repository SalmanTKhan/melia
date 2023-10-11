//--- Melia Script -----------------------------------------------------------
// To Mage Tower
//--- Description -----------------------------------------------------------
// Quest to Go to Fedimian.
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

[QuestScript(50007)]
public class Quest50007Script : QuestScript
{
	protected override void Load()
	{
		SetId(50007);
		SetName("To Mage Tower");
		SetDescription("Go to Fedimian");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ZACHA5F_MQ_05"));

		AddDialogHook("ZACHA5F_MQ_04", "BeforeStart", BeforeStart);
		AddDialogHook("WS_REMAINS40_TO_FEDMIAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


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

