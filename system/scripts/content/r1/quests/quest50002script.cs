//--- Melia Script -----------------------------------------------------------
// Purifying the Great Cathedral
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Prosit.
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

[QuestScript(50002)]
public class Quest50002Script : QuestScript
{
	protected override void Load()
	{
		SetId(50002);
		SetName("Purifying the Great Cathedral");
		SetDescription("Talk to Priest Prosit");

		AddPrerequisite(new LevelPrerequisite(145));

		AddObjective("kill0", "Kill 15 Black Pawnd(s) or Blue Pawndel(s)", new KillObjective(15, 57370, 57371));

		AddDialogHook("CHATHEDRAL56SQ04_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL56SQ04_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL56_SQ04_select01", "CHATHEDRAL56_SQ04", "I will defeat the monsters", "Decline"))
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

		await dialog.Msg("CHATHEDRAL56_SQ04_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

