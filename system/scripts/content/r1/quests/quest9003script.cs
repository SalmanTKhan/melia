//--- Melia Script -----------------------------------------------------------
// Swindler Rexipher
//--- Description -----------------------------------------------------------
// Quest to Talk to Historian Cyrenia Odell.
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

[QuestScript(9003)]
public class Quest9003Script : QuestScript
{
	protected override void Load()
	{
		SetId(9003);
		SetName("Swindler Rexipher");
		SetDescription("Talk to Historian Cyrenia Odell");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS31_REXITHER3_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(78));
		AddPrerequisite(new CompletedPrerequisite("ROKAS31_REXITHER2"));

		AddObjective("kill0", "Kill 6 Hogma Warrior(s) or Hogma Shaman(s) or Hogma Captain(s)", new KillObjective(6, 41433, 41435, 41441));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 10374));

		AddDialogHook("ROKAS31_ODEL2", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS31_ZACHARIEL32", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS31_REXITHER3_select01", "ROKAS31_REXITHER3", "I'll chase Rexipher at the Royal Mausoleum", "I still need more preparation"))
		{
			case 1:
				await dialog.Msg("ROKAS31_REXITHER3_start01");
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

