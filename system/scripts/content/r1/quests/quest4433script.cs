//--- Melia Script -----------------------------------------------------------
// Crazy Archivist (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Niels.
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

[QuestScript(4433)]
public class Quest4433Script : QuestScript
{
	protected override void Load()
	{
		SetId(4433);
		SetName("Crazy Archivist (3)");
		SetDescription("Talk to Niels");

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("ROKAS24_QB_5"));

		AddDialogHook("ROKAS_24_NEALS", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS24_DABIO", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_QB_6_select1", "ROKAS24_QB_6", "I will go see Davio", "About the Archivist Jonas", "Tell him that the medicine won't be effective"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("ROKAS24_QB_6_add");
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

