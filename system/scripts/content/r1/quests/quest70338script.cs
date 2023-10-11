//--- Melia Script -----------------------------------------------------------
// Sharing Given Abilities [Sadhu Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Sadhu master.
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

[QuestScript(70338)]
public class Quest70338Script : QuestScript
{
	protected override void Load()
	{
		SetId(70338);
		SetName("Sharing Given Abilities [Sadhu Advancement]");
		SetDescription("Meet the Sadhu master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 50 Red Tree Ambulo(s)", new KillObjective(50, MonsterId.TreeAmbulo_Red));

		AddDialogHook("JOB_2_SADHU_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_SADHU_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_SADHU5_1_1", "JOB_2_SADHU5", "I will defeat it", "Decline"))
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


		return HookResult.Break;
	}
}

