//--- Melia Script -----------------------------------------------------------
// Where are the Supply Troops (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Officer Danus.
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

[QuestScript(8245)]
public class Quest8245Script : QuestScript
{
	protected override void Load()
	{
		SetId(8245);
		SetName("Where are the Supply Troops (1)");
		SetDescription("Talk to Officer Danus");

		AddPrerequisite(new LevelPrerequisite(114));

		AddDialogHook("KATYN14_LAIMUNAS", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN14_SUPP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN14_MQ_04_01", "KATYN14_MQ_04", "I will find the supply troops", "Decline"))
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

