//--- Melia Script -----------------------------------------------------------
// Secure Route to the Gateway of the Great King (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Commander Julian.
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

[QuestScript(4384)]
public class Quest4384Script : QuestScript
{
	protected override void Load()
	{
		SetId(4384);
		SetName("Secure Route to the Gateway of the Great King (2)");
		SetDescription("Talk to Commander Julian");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN22_Q_13_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(121));
		AddPrerequisite(new CompletedPrerequisite("THORN22_Q_10"));

		AddObjective("kill0", "Kill 8 Wood Goblin(s)", new KillObjective(8, MonsterId.Wood_Goblin));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("THORN22_JULIAN", "BeforeStart", BeforeStart);
		AddDialogHook("THORN22_OROURKE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN22_Q_13_select1", "THORN22_Q_13", "I will apply for it", "I don't have time for that"))
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

		await dialog.Msg("THORN22_Q_13_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

