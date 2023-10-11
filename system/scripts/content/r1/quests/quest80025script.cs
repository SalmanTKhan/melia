//--- Melia Script -----------------------------------------------------------
// Putting Spices (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the villager .
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

[QuestScript(80025)]
public class Quest80025Script : QuestScript
{
	protected override void Load()
	{
		SetId(80025);
		SetName("Putting Spices (1)");
		SetDescription("Talk to the villager ");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_323_SQ_01"));

		AddDialogHook("ORCHARD323_PEOPLE", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_323_SQ_02_start", "ORCHARD_323_SQ_02", "I will come back after polluting it", "That's a bit too much"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORCHARD_323_SQ_03");
	}
}

