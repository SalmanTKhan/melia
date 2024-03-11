//--- Melia Script -----------------------------------------------------------
// Kingdom Reconstruction
//--- Description -----------------------------------------------------------
// Quest to Meet the officer in charge of Orsha's Reconstruction.
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

[QuestScript(510000)]
public class Quest510000Script : QuestScript
{
	protected override void Load()
	{
		SetId(510000);
		SetName("Kingdom Reconstruction");
		SetDescription("Meet the officer in charge of Orsha's Reconstruction");

		AddPrerequisite(new LevelPrerequisite(458));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_5_MQ_07"));

		AddDialogHook("EP13_WEEK_REPUTATION_01", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_WEEK_REPUTATION_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REPUTATION_OPEN_QUEST_DLG1", "REPUTATION_OPEN_QUEST", "I will sponsor and help the Royal Reconstruction", "I can't believe you"))
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

		//TX_GODDESS_CARD_OPEN
		// Func/REPUTATION_EP13_OPEN;
		await dialog.Msg("REPUTATION_OPEN_QUEST_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

