//--- Melia Script -----------------------------------------------------------
// Rexipher's True Colors (1)
//--- Description -----------------------------------------------------------
// Quest to Trace Rexipher's whereabouts.
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

[QuestScript(20191)]
public class Quest20191Script : QuestScript
{
	protected override void Load()
	{
		SetId(20191);
		SetName("Rexipher's True Colors (1)");
		SetDescription("Trace Rexipher's whereabouts");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS30_MQ4_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(76));
		AddPrerequisite(new CompletedPrerequisite("ROKAS30_MQ2"));

		AddObjective("kill0", "Kill 5 Hogma Warrior(s) or Hogma Captain(s) or Hogma Fighter(s)", new KillObjective(5, 41433, 41441, 47308));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 1444));

		AddDialogHook("ROKAS30_HURT", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS30_MQ3_select01", "ROKAS30_MQ3", "Yeah, that's correct", "I don't think so"))
		{
			case 1:
				await dialog.Msg("ROKAS30_MQ3_start01");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

