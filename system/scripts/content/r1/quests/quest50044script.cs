//--- Melia Script -----------------------------------------------------------
// The Sealed Tower of the Goddess (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Ramelie.
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

[QuestScript(50044)]
public class Quest50044Script : QuestScript
{
	protected override void Load()
	{
		SetId(50044);
		SetName("The Sealed Tower of the Goddess (1)");
		SetDescription("Talk to Priest Ramelie");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PARTY_Q_100_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(100));

		AddDialogHook("SIAULIAI_46_2_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_2_MQ01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PARTY_Q_100_startnpc01", "PARTY_Q_100", "I will help to protect the sealed tower", "Tell him that it can't be helped"))
		{
			case 1:
				await dialog.Msg("PARTY_Q_100_AG");
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

		await dialog.Msg("PARTY_Q_100_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

