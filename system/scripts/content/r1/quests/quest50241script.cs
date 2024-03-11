//--- Melia Script -----------------------------------------------------------
// Faint Vision [Oracle Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Oracle Master.
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

[QuestScript(50241)]
public class Quest50241Script : QuestScript
{
	protected override void Load()
	{
		SetId(50241);
		SetName("Faint Vision [Oracle Advancement]");
		SetDescription("Talk to the Oracle Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddObjective("kill0", "Kill 20 Blue Nuka(s) or Blue Elma(s) or Brown Terra Imp Archer(s)", new KillObjective(20, 57985, 57987, 57952));

		AddDialogHook("MASTER_ORACLE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ORACLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_ORACLE_7_1_START1", "JOB_ORACLE_7_1", "I will resolve it", "I will think about it."))
		{
			case 1:
				await dialog.Msg("JOB_ORACLE_7_1_AGREE1");
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

		await dialog.Msg("JOB_ORACLE_7_1_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

