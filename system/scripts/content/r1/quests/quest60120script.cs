//--- Melia Script -----------------------------------------------------------
// Bishop Urbonas' Whereabouts (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Bishop Urbonas.
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

[QuestScript(60120)]
public class Quest60120Script : QuestScript
{
	protected override void Load()
	{
		SetId(60120);
		SetName("Bishop Urbonas' Whereabouts (5)");
		SetDescription("Talk to Bishop Urbonas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PRISON621_MQ_06_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PRISON621_MQ_05"));

		AddDialogHook("PRISON621_URBONAS", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON621_URBONAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON621_MQ_06_01", "PRISON621_MQ_06", "What should I do?", "That's absurd"))
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

