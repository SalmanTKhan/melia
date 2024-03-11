//--- Melia Script -----------------------------------------------------------
// Old Story (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Coben.
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

[QuestScript(8456)]
public class Quest8456Script : QuestScript
{
	protected override void Load()
	{
		SetId(8456);
		SetName("Old Story (5)");
		SetDescription("Talk to Coben");

		AddPrerequisite(new LevelPrerequisite(107));
		AddPrerequisite(new CompletedPrerequisite("REMAINS40_MQ_04"));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("REMAINS_40_DRUNK_02", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS_40_DRUNK_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS40_MQ_05_01", "REMAINS40_MQ_05", "I'll read what's written on the tombstone.", "Decline"))
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

		await dialog.Msg("REMAINS40_MQ_05_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

