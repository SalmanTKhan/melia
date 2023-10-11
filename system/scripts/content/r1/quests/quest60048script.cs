//--- Melia Script -----------------------------------------------------------
// A Dead End (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Member Alina.
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

[QuestScript(60048)]
public class Quest60048Script : QuestScript
{
	protected override void Load()
	{
		SetId(60048);
		SetName("A Dead End (2)");
		SetDescription("Talk with Member Alina");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM311_SQ_05"));

		AddObjective("kill0", "Kill 11 Hallowventer(s) or Ellomago(s) or Old Hook(s)", new KillObjective(11, 58143, 58144, 58145));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1640));

		AddDialogHook("PILGRIM311_ALINA", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM311_ALINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM311_SQ_06_01", "PILGRIM311_SQ_06", "I'll take care of it", "I'll wait a little bit"))
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

