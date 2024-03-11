//--- Melia Script -----------------------------------------------------------
// Food Reserve (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Tauras.
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

[QuestScript(40430)]
public class Quest40430Script : QuestScript
{
	protected override void Load()
	{
		SetId(40430);
		SetName("Food Reserve (3)");
		SetDescription("Talk to Tauras");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FARM47_1_SQ_070_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(93));
		AddPrerequisite(new CompletedPrerequisite("FARM47_1_SQ_060"));

		AddObjective("kill0", "Kill 20 White Pino(s) or White Geppetto(s)", new KillObjective(20, 57329, 57328));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1860));

		AddDialogHook("FARM47_TAURAS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_TAURAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_1_SQ_070_ST", "FARM47_1_SQ_070", "I will protect the storage", "I will go now"))
		{
			case 1:
				await dialog.Msg("FARM47_1_SQ_070_AC");
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

		await dialog.Msg("FARM47_1_SQ_070_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

