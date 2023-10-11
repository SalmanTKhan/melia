//--- Melia Script -----------------------------------------------------------
// Mysterious Incident
//--- Description -----------------------------------------------------------
// Quest to Pilgrim Gracius.
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

[QuestScript(19620)]
public class Quest19620Script : QuestScript
{
	protected override void Load()
	{
		SetId(19620);
		SetName("Mysterious Incident");
		SetDescription("Pilgrim Gracius");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM50_SQ_010_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(127));

		AddObjective("kill0", "Kill 25 Kodomor(s) or Lomor(s)", new KillObjective(25, 41450, 57403));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 3175));

		AddDialogHook("PILGRIM50_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM50_NPC01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM50_SQ_010_ST", "PILGRIM50_SQ_010", "Let's just look at it quietly without disturbing", "Fine, have it your way. I'm leaving"))
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

		await dialog.Msg("PILGRIM50_SQ_010_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

