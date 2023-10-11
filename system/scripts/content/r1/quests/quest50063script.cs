//--- Melia Script -----------------------------------------------------------
// Special Powers Discovered by the Monocle (1)
//--- Description -----------------------------------------------------------
// Quest to Speak with Grave Robber Amanda in the Residents' Area of the Fortress of the Land.
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

[QuestScript(50063)]
public class Quest50063Script : QuestScript
{
	protected override void Load()
	{
		SetId(50063);
		SetName("Special Powers Discovered by the Monocle (1)");
		SetDescription("Speak with Grave Robber Amanda in the Residents' Area of the Fortress of the Land");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "UNDERFORTRESS_67_MQ010_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(207));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_66_MQ070"));

		AddObjective("kill0", "Kill 4 Brown Rambear(s) or Brown Rambear Archer(s) or Brown Rambear Magician(s)", new KillObjective(4, 57964, 57965, 57966));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7245));

		AddDialogHook("AMANDA_67_1", "BeforeStart", BeforeStart);
		AddDialogHook("AMANDA_67_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDER_67_MQ010_startnpc01", "UNDERFORTRESS_67_MQ010", "Could you search the area just one more time? ", "Wait a moment"))
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

		await dialog.Msg("UNDERFORTRESS_67_MQ070_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

