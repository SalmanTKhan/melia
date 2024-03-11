//--- Melia Script -----------------------------------------------------------
// Statue of Peace (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Elder's grandchild.
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

[QuestScript(80027)]
public class Quest80027Script : QuestScript
{
	protected override void Load()
	{
		SetId(80027);
		SetName("Statue of Peace (1)");
		SetDescription("Talk to the Elder's grandchild");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_323_MQ_06"));

		AddDialogHook("ORCHARD323_GRANDSON", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD323_VYDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_323_SQ_04_start", "ORCHARD_323_SQ_04", "I will find out more about it", "Decline"))
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

