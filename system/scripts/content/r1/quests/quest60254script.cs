//--- Melia Script -----------------------------------------------------------
// Going Below the Shadow (7)
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

[QuestScript(60254)]
public class Quest60254Script : QuestScript
{
	protected override void Load()
	{
		SetId(60254);
		SetName("Going Below the Shadow (7)");
		SetDescription("Talk to Neringa");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FANTASYLIB482_MQ_7_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(338));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB482_MQ_6"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("FLIBRARY482_NERINGA_NPC_3", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY482_NERINGA_NPC_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB482_MQ_7_1", "FANTASYLIB482_MQ_7", "I'm ready", "What are you talking about?"))
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

		await dialog.Msg("FANTASYLIB482_MQ_7_3");
		dialog.HideNPC("FLIBRARY482_NERINGA_NPC_3");
		await dialog.Msg("FadeOutIN/2000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

