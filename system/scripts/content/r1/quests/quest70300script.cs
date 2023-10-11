//--- Melia Script -----------------------------------------------------------
// The Swordsman's Qualities [Swordsman Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Swordsman Submaster.
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

[QuestScript(70300)]
public class Quest70300Script : QuestScript
{
	protected override void Load()
	{
		SetId(70300);
		SetName("The Swordsman's Qualities [Swordsman Advancement]");
		SetDescription("Talk with the Swordsman Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 10 Red Kepa(s)", new KillObjective(10, MonsterId.Sec_Onion_Red));
		AddObjective("kill1", "Kill 10 Woodin(s)", new KillObjective(10, MonsterId.Woodin));

		AddDialogHook("JOB_2_SWORDMAN_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_SWORDMAN_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_SWORDMAN2_1_1", "JOB_2_SWORDMAN2", "I want to become stronger of course", "Your competence is enough"))
		{
			case 1:
				await dialog.Msg("JOB_2_SWORDMAN2_1_2");
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

