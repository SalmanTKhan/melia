//--- Melia Script -----------------------------------------------------------
// Each Step United
//--- Description -----------------------------------------------------------
// Quest to Meet Commander Uska.
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

[QuestScript(19091)]
public class Quest19091Script : QuestScript
{
	protected override void Load()
	{
		SetId(19091);
		SetName("Each Step United");
		SetDescription("Meet Commander Uska");

		AddPrerequisite(new LevelPrerequisite(130));

		AddObjective("kill0", "Kill 100 Prison Fighter(s) or Kowak(s) or Stoulet Archer(s)", new KillObjective(100, 41315, 41451, 57613));

		AddDialogHook("KLAPEDA_USKA", "BeforeStart", BeforeStart);
		AddDialogHook("KLAPEDA_USKA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_14_HQ_01_ST", "KATYN_14_HQ_01", "I'll help subjugate", "Decline"))
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

		await dialog.Msg("KATYN_14_HQ_01_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

