//--- Melia Script -----------------------------------------------------------
// [Sadhu] The Disciplinant of Spirit
//--- Description -----------------------------------------------------------
// Quest to Find the Sadhu Master at Akmens Ridge.
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

[QuestScript(550003)]
public class Quest550003Script : QuestScript
{
	protected override void Load()
	{
		SetId(550003);
		SetName("[Sadhu] The Disciplinant of Spirit");
		SetDescription("Find the Sadhu Master at Akmens Ridge");

		AddPrerequisite(new LevelPrerequisite(1));

		AddDialogHook("JOB_SADU3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SADU3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UQ_Char4_6_PRE2_Quest_DLG_1", "UQ_Char4_6_PRE2", "I am ready to practice the asceticism", "I'm in pain enough for now"))
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

		await dialog.Msg("UQ_Char4_6_PRE2_Quest_DLG_3");
		// Func/SCR_SET_UNLOCK_AOBJ_LOCK;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

