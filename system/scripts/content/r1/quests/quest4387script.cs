//--- Melia Script -----------------------------------------------------------
// Secure Route to the Gateway of the Great King (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with O'Rourke.
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

[QuestScript(4387)]
public class Quest4387Script : QuestScript
{
	protected override void Load()
	{
		SetId(4387);
		SetName("Secure Route to the Gateway of the Great King (3)");
		SetDescription("Talk with O'Rourke");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN22_Q_16_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(121));
		AddPrerequisite(new CompletedPrerequisite("THORN22_Q_13"));

		AddObjective("kill0", "Kill 5 Wood Goblin(s) or Meleech(s)", new KillObjective(5, 41290, 41285));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("THORN22_OROURKE", "BeforeStart", BeforeStart);
		AddDialogHook("THORN22_Q_18", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN22_Q_16_select1", "THORN22_Q_16", "I will find it", "It looks dangerous"))
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

		await dialog.Msg("THORN22_Q_16_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

