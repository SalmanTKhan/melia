//--- Melia Script -----------------------------------------------------------
// The Vulnerable Fugitive (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Grisia.
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

[QuestScript(60286)]
public class Quest60286Script : QuestScript
{
	protected override void Load()
	{
		SetId(60286);
		SetName("The Vulnerable Fugitive (6)");
		SetDescription("Talk to Kupole Grisia");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "DCAPITAL105_SQ_6_TRACK", 8000);

		AddPrerequisite(new LevelPrerequisite(371));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL105_SQ_5"));

		AddObjective("kill0", "Kill 6 Bishop Star(s)", new KillObjective(6, MonsterId.Bishopstar));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 20628));

		AddDialogHook("DCAPITAL105_GRISIA_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL105_GRISIA_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL105_SQ_6_1", "DCAPITAL105_SQ_6", "I'll try to find them", "I need to prepare"))
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

		await dialog.Msg("DCAPITAL105_SQ_6_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

