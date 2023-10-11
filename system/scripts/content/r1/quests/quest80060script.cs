//--- Melia Script -----------------------------------------------------------
// The Results for Them
//--- Description -----------------------------------------------------------
// Quest to Talk with Necromancer Lemija.
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

[QuestScript(80060)]
public class Quest80060Script : QuestScript
{
	protected override void Load()
	{
		SetId(80060);
		SetName("The Results for Them");
		SetDescription("Talk with Necromancer Lemija");

		AddPrerequisite(new LevelPrerequisite(208));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_11_1_SQ_08"));

		AddReward(new ItemReward("TABLELAND_11_1_BOOK_2", 1));

		AddDialogHook("TABLELAND_11_1_LEMIJA3", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND_11_1_LEMIJA3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_11_1_SQ_09_start", "TABLELAND_11_1_SQ_09", "I'll wait then", "We don't have time for it"))
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

		await dialog.Msg("TABLELAND_11_1_SQ_09_succ");
		// Func/TABLELAND_11_1_SQ_09_COMP;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

