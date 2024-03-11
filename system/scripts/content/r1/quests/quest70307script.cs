//--- Melia Script -----------------------------------------------------------
// Overcoming Hardship [Swordsman Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Swordsman Submaster.
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

[QuestScript(70307)]
public class Quest70307Script : QuestScript
{
	protected override void Load()
	{
		SetId(70307);
		SetName("Overcoming Hardship [Swordsman Advancement]");
		SetDescription("Talk with the Swordsman Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 30 Gosaru(s)", new KillObjective(30, MonsterId.Gosaru));

		AddDialogHook("JOB_2_SWORDMAN_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_SWORDMAN_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_SWORDMAN3_1_1", "JOB_2_SWORDMAN3", "I'll do what I have to do", "I don't want to push myself too far anymore"))
		{
			case 1:
				await dialog.Msg("JOB_2_SWORDMAN3_1_2");
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

