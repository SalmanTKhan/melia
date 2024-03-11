//--- Melia Script -----------------------------------------------------------
// Extinct Mirtinas (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Ragana.
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

[QuestScript(92029)]
public class Quest92029Script : QuestScript
{
	protected override void Load()
	{
		SetId(92029);
		SetName("Extinct Mirtinas (2)");
		SetDescription("Talk to Ragana");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP13_F_SIAULIAI_5_MQ_03_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(458));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_5_MQ_02"));

		AddReward(new ItemReward("expCard18", 22));
		AddReward(new ItemReward("Vis", 28396));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 33));

		AddDialogHook("EP13_F_SIAULIAI_5_RAGANA", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_5_BAIGA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_5_MQ_03_DLG1", "EP13_F_SIAULIAI_5_MQ_03"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		dialog.UnHideNPC("EP13_F_SIAULIAI_5_BAIGA");
		await dialog.Msg("EP13_F_SIAULIAI_5_MQ_03_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

