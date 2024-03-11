//--- Melia Script -----------------------------------------------------------
// Reducing the Danger
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Wiley.
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

[QuestScript(70107)]
public class Quest70107Script : QuestScript
{
	protected override void Load()
	{
		SetId(70107);
		SetName("Reducing the Danger");
		SetDescription("Talk to Monk Wiley");

		AddPrerequisite(new LevelPrerequisite(173));

		AddObjective("kill0", "Kill 12 Green Velwriggler Mage(s) or Green Cockat(s) or Rocktor(s)", new KillObjective(12, 57675, 401642, 41197));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5190));

		AddDialogHook("THORN392_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("THORN392_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_2_SQ_02_1", "THORN39_2_SQ02", "Tell him that you could handle the task", "Decline"))
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

		await dialog.Msg("THORN39_2_SQ_02_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

