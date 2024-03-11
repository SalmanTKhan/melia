//--- Melia Script -----------------------------------------------------------
// The Disappearance of Soldiers
//--- Description -----------------------------------------------------------
// Quest to Talk to Refugee Representative Morkus.
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

[QuestScript(90119)]
public class Quest90119Script : QuestScript
{
	protected override void Load()
	{
		SetId(90119);
		SetName("The Disappearance of Soldiers");
		SetDescription("Talk to Refugee Representative Morkus");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("MAPLE_25_2_MORKUS", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_2_MORKUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_2_SQ_10_ST", "MAPLE_25_2_SQ_10", "I'll help", "About why here", "Look behind you, a three-headed monkey!"))
		{
			case 1:
				await dialog.Msg("MAPLE_25_2_SQ_10_AG");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("MAPLE_25_2_SQ_10_ADD");
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

