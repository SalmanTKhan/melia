//--- Melia Script -----------------------------------------------------------
// The Mysterious Girl (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Village Headman.
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

[QuestScript(80023)]
public class Quest80023Script : QuestScript
{
	protected override void Load()
	{
		SetId(80023);
		SetName("The Mysterious Girl (3)");
		SetDescription("Talk to the Village Headman");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_323_MQ_05"));

		AddDialogHook("ORCHARD323_MAYOR", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_323_MQ_06_start", "ORCHARD_323_MQ_06", "I will follow it", "Why can't you ask for help around here?", "Tell him that you need some time to think"))
		{
			case 1:
				dialog.UnHideNPC("ORCHARD323_TRACE");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("ORCHARD_323_MQ_06_add");
				break;
		}

		return HookResult.Break;
	}
}

