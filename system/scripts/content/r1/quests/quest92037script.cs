//--- Melia Script -----------------------------------------------------------
// Attack is the Best Defense (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(92037)]
public class Quest92037Script : QuestScript
{
	protected override void Load()
	{
		SetId(92037);
		SetName("Attack is the Best Defense (1)");
		SetDescription("Talk to Pajauta");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP13_F_SIAULIAI_1_SQ_04_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_1_SQ_03"));

		AddReward(new ItemReward("Vis", 27900));
		AddReward(new ItemReward("expCard18", 2));

		AddDialogHook("EP13_SUB_PAYAUTA_NPC_SIAU_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_SUB_PAYAUTA_NPC_SIAU_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_1_SQ_04_1", "EP13_F_SIAULIAI_1_SQ_04", "I'll help you", "I don't like the plan"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("EP13_F_SIAULIAI_1_SQ_04_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

