//--- Melia Script -----------------------------------------------------------
// [Keraunos] Thunder Flower
//--- Description -----------------------------------------------------------
// Quest to Go to Keraunos Master in Pyromancer Master's Lab.
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

[QuestScript(550008)]
public class Quest550008Script : QuestScript
{
	protected override void Load()
	{
		SetId(550008);
		SetName("[Keraunos] Thunder Flower");
		SetDescription("Go to Keraunos Master in Pyromancer Master's Lab");

		AddPrerequisite(new LevelPrerequisite(1));

		AddDialogHook("MASTER_CHAR2_24_CITY", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CHAR2_24_CITY", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UQ_Char2_24_PRE2_DLG1", "UQ_Char2_24_PRE2", "Alright, I'll help you", "Sorry, something else came up"))
		{
			case 1:
				// Func/SCR_SET_UNLOCK_AOBJ_UNLOCK;
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

		// Func/SCR_SET_UNLOCK_AOBJ_LOCK;
		await dialog.Msg("UQ_Char2_24_PRE2_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

