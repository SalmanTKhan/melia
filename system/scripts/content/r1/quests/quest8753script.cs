//--- Melia Script -----------------------------------------------------------
// Heated Arrowhead
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Talus.
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

[QuestScript(8753)]
public class Quest8753Script : QuestScript
{
	protected override void Load()
	{
		SetId(8753);
		SetName("Heated Arrowhead");
		SetDescription("Talk to Hunter Talus");

		AddPrerequisite(new LevelPrerequisite(99));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1980));

		AddDialogHook("REMAIN38_HUNTER", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN38_HUNTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN38_MQ07_01", "REMAIN38_MQ07", "I'll help you.", "Decline"))
		{
			case 1:
				await dialog.Msg("REMAIN38_MQ07_AG");
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

		await dialog.Msg("REMAIN38_MQ07_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

