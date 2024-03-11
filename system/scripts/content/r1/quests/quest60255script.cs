//--- Melia Script -----------------------------------------------------------
// Necessary Mistake (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(60255)]
public class Quest60255Script : QuestScript
{
	protected override void Load()
	{
		SetId(60255);
		SetName("Necessary Mistake (1)");
		SetDescription("Talk to Neringa");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FANTASYLIB483_MQ_1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(341));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB482_MQ_7"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("FLIBRARY483_NERINGA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY483_NERINGA_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB483_MQ_1_1", "FANTASYLIB483_MQ_1", "Of course", "Wait for a while"))
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

		await dialog.Msg("FANTASYLIB483_MQ_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

