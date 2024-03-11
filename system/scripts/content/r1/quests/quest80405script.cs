//--- Melia Script -----------------------------------------------------------
// Fruit of Vengeance
//--- Description -----------------------------------------------------------
// Quest to Talk to Audrone at Freenel Memorial.
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

[QuestScript(80405)]
public class Quest80405Script : QuestScript
{
	protected override void Load()
	{
		SetId(80405);
		SetName("Fruit of Vengeance");
		SetDescription("Talk to Audrone at Freenel Memorial");

		AddPrerequisite(new LevelPrerequisite(380));

		AddObjective("kill0", "Kill 1 Asiomage", new KillObjective(1, MonsterId.Boss_Asiomage_Mission_Quest));

		AddDialogHook("ASIOMAGE_ENTER_01", "BeforeStart", BeforeStart);
		AddDialogHook("ASIOMAGE_ENTER_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_BRACKEN_UNIQUE_MQ1_ST", "F_BRACKEN_UNIQUE_MQ1", "Leave it to me.", "I'm not ready yet."))
		{
			case 1:
				await dialog.Msg("F_BRACKEN_UNIQUE_MQ1_AFST");
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

		await dialog.Msg("F_BRACKEN_UNIQUE_MQ1_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

