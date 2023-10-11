//--- Melia Script -----------------------------------------------------------
// Hunting Standards [Hunter Advancement]
//--- Description -----------------------------------------------------------
// Quest to Go to the Hunter Master.
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

[QuestScript(8719)]
public class Quest8719Script : QuestScript
{
	protected override void Load()
	{
		SetId(8719);
		SetName("Hunting Standards [Hunter Advancement]");
		SetDescription("Go to the Hunter Master");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 10 Ducky(s)", new KillObjective(10, MonsterId.Duckey));
		AddObjective("kill1", "Kill 10 Black Drake(s)", new KillObjective(10, MonsterId.Fire_Dragon_Purple));
		AddObjective("kill2", "Kill 10 Kowak(s)", new KillObjective(10, MonsterId.Kowak));

		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HUNTER4_1_01", "JOB_HUNTER4_1", "Tell him you would challenge for it", "I'll wait a little bit"))
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

		await dialog.Msg("JOB_HUNTER4_1_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

