//--- Melia Script -----------------------------------------------------------
// Preserve the Evidence of the Outter Wall
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Milda.
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

[QuestScript(30253)]
public class Quest30253Script : QuestScript
{
	protected override void Load()
	{
		SetId(30253);
		SetName("Preserve the Evidence of the Outter Wall");
		SetDescription("Talk to Kupole Milda");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 16 Akhlass Petal(s) or Akhlass Steel(s) or Akhlacia(s) or Akhlass Countess(s)", new KillObjective(16, 58609, 58610, 58611, 58613));

		AddDialogHook("CASTLE_20_1_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_1_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE_20_1_SQ_11_select", "CASTLE_20_1_SQ_11", "I'll get rid of the monsters", "Let's escape it before that happens."))
		{
			case 1:
				await dialog.Msg("CASTLE_20_1_SQ_11_agree");
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

		await dialog.Msg("CASTLE_20_1_SQ_11_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

