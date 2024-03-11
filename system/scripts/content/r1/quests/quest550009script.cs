//--- Melia Script -----------------------------------------------------------
// [Lama] Rescuer's Path
//--- Description -----------------------------------------------------------
// Quest to Go to the Lama Master at the Saalus Convent.
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

[QuestScript(550009)]
public class Quest550009Script : QuestScript
{
	protected override void Load()
	{
		SetId(550009);
		SetName("[Lama] Rescuer's Path");
		SetDescription("Go to the Lama Master at the Saalus Convent");

		AddPrerequisite(new LevelPrerequisite(1));

		AddDialogHook("MASTER_LAMA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_LAMA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UQ_Char4_22_PRE1_DLG1", "UQ_Char4_22_PRE1", "I will dedicate myself to helping the weak.", "I have more important things to do."))
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
		await dialog.Msg("UQ_Char4_22_PRE1_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

