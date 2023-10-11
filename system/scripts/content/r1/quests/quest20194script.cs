//--- Melia Script -----------------------------------------------------------
// Rexipher's True Colors (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Historian Cyrenia Odell.
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

[QuestScript(20194)]
public class Quest20194Script : QuestScript
{
	protected override void Load()
	{
		SetId(20194);
		SetName("Rexipher's True Colors (3)");
		SetDescription("Talk to Historian Cyrenia Odell");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS30_MQ6_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(76));
		AddPrerequisite(new CompletedPrerequisite("ROKAS30_MQ5"));

		AddObjective("kill0", "Kill 5 Hogma Fighter(s) or Hogma Scout(s) or Hogma Captain(s) or Hogma Archer(s) or Hogma Shaman(s)", new KillObjective(5, 47308, 47309, 41441, 41434, 41435));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 1444));

		AddDialogHook("ROKAS_ODEL2", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_ODEL2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS30_MQ6_select01", "ROKAS30_MQ6", "Explain about Rexipher and the symbols", "About the Altar here", "Better keep quiet"))
		{
			case 1:
				await dialog.Msg("ROKAS30_MQ6_start01");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
			case 2:
				await dialog.Msg("ROKAS30_MQ6_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("ROKAS30_MQ6_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

