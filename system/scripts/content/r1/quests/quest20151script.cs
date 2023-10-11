//--- Melia Script -----------------------------------------------------------
// Gorath's Concern (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Gorath.
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

[QuestScript(20151)]
public class Quest20151Script : QuestScript
{
	protected override void Load()
	{
		SetId(20151);
		SetName("Gorath's Concern (1)");
		SetDescription("Talk to Gorath");

		AddPrerequisite(new LevelPrerequisite(58));

		AddDialogHook("ROKAS_24_GORATH", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_ARCHAEOLOGIST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_SQ_02_select01", "ROKAS24_SQ_02", "I will find it", "Don't worry. They will return soon."))
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

