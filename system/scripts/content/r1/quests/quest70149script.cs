//--- Melia Script -----------------------------------------------------------
// Until the last one
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Jeffrey.
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

[QuestScript(70149)]
public class Quest70149Script : QuestScript
{
	protected override void Load()
	{
		SetId(70149);
		SetName("Until the last one");
		SetDescription("Talk to Monk Jeffrey");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Giant Wood Goblin", new KillObjective(1, MonsterId.Boss_GiantWoodGoblin));

		AddDialogHook("THORN393_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("THORN393_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_3_SQ_04_1", "THORN39_3_SQ04", "I will try my best", "He is too much for me"))
		{
			case 1:
				await dialog.Msg("THORN39_3_SQ_04_2");
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

		await dialog.Msg("THORN39_3_SQ_04_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

