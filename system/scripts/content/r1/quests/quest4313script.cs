//--- Melia Script -----------------------------------------------------------
// Crazy Archivist (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Liaison Officer Niels.
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

[QuestScript(4313)]
public class Quest4313Script : QuestScript
{
	protected override void Load()
	{
		SetId(4313);
		SetName("Crazy Archivist (1)");
		SetDescription("Talk to Liaison Officer Niels");

		AddPrerequisite(new LevelPrerequisite(58));

		AddDialogHook("ROKAS_24_NEALS", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_DIALOG1_select1", "ROKAS24_DIALOG1", "I will bring him back if I find him", "I will search for him"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

