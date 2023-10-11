//--- Melia Script -----------------------------------------------------------
// Protect the Heritage (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Epigraphist Raymond.
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

[QuestScript(20200)]
public class Quest20200Script : QuestScript
{
	protected override void Load()
	{
		SetId(20200);
		SetName("Protect the Heritage (1)");
		SetDescription("Talk to Epigraphist Raymond");

		AddPrerequisite(new LevelPrerequisite(96));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1920));

		AddDialogHook("REMAIN37_RAYMOND", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN37_RAYMOND", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN37_MQ04_select01", "REMAIN37_MQ04", "I'll find the piece of memorial", "I'm not interested"))
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

		await dialog.Msg("REMAIN37_MQ04_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

