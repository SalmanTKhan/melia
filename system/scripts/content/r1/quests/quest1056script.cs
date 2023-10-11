//--- Melia Script -----------------------------------------------------------
// Treasure Map of the Stonemason's Family (3)
//--- Description -----------------------------------------------------------
// Quest to Move to the marked area on Stonemason Pipoti's map.
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

[QuestScript(1056)]
public class Quest1056Script : QuestScript
{
	protected override void Load()
	{
		SetId(1056);
		SetName("Treasure Map of the Stonemason's Family (3)");
		SetDescription("Move to the marked area on Stonemason Pipoti's map");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS30_PIPOTI04_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(76));
		AddPrerequisite(new CompletedPrerequisite("ROKAS30_PIPOTI03"));

		AddObjective("kill0", "Kill 5 Hogma Warrior(s) or Hogma Shaman(s)", new KillObjective(5, 41433, 41435));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1444));

		AddDialogHook("ROKAS30_PIPOTI04_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS30_PIPOTI04_TREASUREBOX", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		// Func/SCR_ROKAS30_PIPOTI04_TREASUREBOX_OPEN;
		await Task.Delay(1000);
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The treasure chest was empty!{nl}Right-click on the treasure map and look for the next location!");
		dialog.UnHideNPC("ROKAS30_TREASUREBOX98");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

