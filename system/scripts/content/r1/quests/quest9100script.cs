//--- Melia Script -----------------------------------------------------------
// Military Support
//--- Description -----------------------------------------------------------
// Quest to Talk to Knight Titas.
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

[QuestScript(9100)]
public class Quest9100Script : QuestScript
{
	protected override void Load()
	{
		SetId(9100);
		SetName("Military Support");
		SetDescription("Talk to Knight Titas");

		AddPrerequisite(new LevelPrerequisite(103));

		AddObjective("kill0", "Kill 100 Meleech(s) or Ravinelarva(s) or Treegool(s) or Wood Goblin(s)", new KillObjective(100, 41285, 41269, 41264, 41290));

		AddDialogHook("SIAUL_WEST_CAMP_MANAGER", "BeforeStart", BeforeStart);
		AddDialogHook("THORN22_JULIAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAUL_WEST_HQ_01_select01", "SIAUL_WEST_HQ_01", "I still want to help", "Continue going your way"))
		{
			case 1:
				await dialog.Msg("SIAUL_WEST_HQ_01_startnpc01");
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

		await dialog.Msg("SIAUL_WEST_HQ_01_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

