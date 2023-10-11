//--- Melia Script -----------------------------------------------------------
// Trick of the Demon (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Guardian Stone Statue.
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

[QuestScript(20165)]
public class Quest20165Script : QuestScript
{
	protected override void Load()
	{
		SetId(20165);
		SetName("Trick of the Demon (1)");
		SetDescription("Talk to the Guardian Stone Statue");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA2F_MQ_02_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(84));
		AddPrerequisite(new CompletedPrerequisite("ZACHA2F_MQ_01"));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("ZACHARIEL33_GUARDIAN2", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHARIEL33_GUARDIAN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA2F_MQ_02_select_01", "ZACHA2F_MQ_02", "I'll guard the stone lantern of the Royal Mausoleum", "I'll wait a little bit"))
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


		return HookResult.Break;
	}
}

