//--- Melia Script -----------------------------------------------------------
// Expired Contract
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

[QuestScript(8404)]
public class Quest8404Script : QuestScript
{
	protected override void Load()
	{
		SetId(8404);
		SetName("Expired Contract");
		SetDescription("Talk to Treasure Hunter Eden");

		AddPrerequisite(new LevelPrerequisite(96));
		AddPrerequisite(new CompletedPrerequisite("REMAIN37_SQ02"), new CompletedPrerequisite("REMAIN37_SQ04"));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 1920));

		AddDialogHook("REMAIN37_SQ6_UNCLE1", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN37_SMEADE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN37_SQ05_01", "REMAIN37_SQ05", "Say that you will do it", "Tell him to give it to him directly"))
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

		await dialog.Msg("REMAIN37_SQ05_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

