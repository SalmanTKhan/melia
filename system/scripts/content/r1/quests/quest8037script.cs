//--- Melia Script -----------------------------------------------------------
// Merchant's Mercenary
//--- Description -----------------------------------------------------------
// Quest to Talk to Vio.
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

[QuestScript(8037)]
public class Quest8037Script : QuestScript
{
	protected override void Load()
	{
		SetId(8037);
		SetName("Merchant's Mercenary");
		SetDescription("Talk to Vio");

		AddPrerequisite(new LevelPrerequisite(64));

		AddDialogHook("ROKAS26_BIO", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS26_BIO", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS26_SUB_Q01_01", "ROKAS26_SUB_Q01", "Tell him that you will tell them to go back to the camp if you see them", "I'm busy"))
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

