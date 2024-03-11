//--- Melia Script -----------------------------------------------------------
// Weird Fellows
//--- Description -----------------------------------------------------------
// Quest to Talk to Treasure Hunter Eden.
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

[QuestScript(20204)]
public class Quest20204Script : QuestScript
{
	protected override void Load()
	{
		SetId(20204);
		SetName("Weird Fellows");
		SetDescription("Talk to Treasure Hunter Eden");

		AddPrerequisite(new LevelPrerequisite(96));

		AddObjective("kill0", "Kill 15 Tama(s)", new KillObjective(15, MonsterId.Tama));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1920));

		AddDialogHook("REMAIN37_SQ6_UNCLE1", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN37_SQ6_UNCLE1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN37_SQ01_select01", "REMAIN37_SQ01", "Poor thing. Let's help", "I suggest you train hard"))
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

		await dialog.Msg("REMAIN37_SQ01_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

