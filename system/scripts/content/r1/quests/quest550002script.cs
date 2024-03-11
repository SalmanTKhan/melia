//--- Melia Script -----------------------------------------------------------
// [Luchador] Figure of a Superstar
//--- Description -----------------------------------------------------------
// Quest to Go to El Volador Mascaras at Saalus Convent.
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

[QuestScript(550002)]
public class Quest550002Script : QuestScript
{
	protected override void Load()
	{
		SetId(550002);
		SetName("[Luchador] Figure of a Superstar");
		SetDescription("Go to El Volador Mascaras at Saalus Convent");

		AddPrerequisite(new LevelPrerequisite(1));

		AddDialogHook("MASTER_LUCHADOR_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_LUCHADOR_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UQ_Char1_23_PRE2_DLG1", "UQ_Char1_23_PRE2", "I will show you that I am qualified person.", "I'm afraid not."))
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
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

