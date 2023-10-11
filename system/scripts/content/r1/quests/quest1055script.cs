//--- Melia Script -----------------------------------------------------------
// Treasure Map of the Stonemason's Family (2)
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

[QuestScript(1055)]
public class Quest1055Script : QuestScript
{
	protected override void Load()
	{
		SetId(1055);
		SetName("Treasure Map of the Stonemason's Family (2)");
		SetDescription("Move to the marked area on Stonemason Pipoti's map");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS30_PIPOTI03_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(76));
		AddPrerequisite(new CompletedPrerequisite("ROKAS30_PIPOTI02"));

		AddObjective("kill0", "Kill 6 Hogma Scout(s)", new KillObjective(6, MonsterId.Hogma_Guard));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1444));

		AddDialogHook("ROKAS30_PIPOTI03_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS30_PIPOTI03_TREASUREBOX", "BeforeEnd", BeforeEnd);
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

		// Func/SCR_ROKAS30_PIPOTI03_TREASUREBOX_OPEN;
		await Task.Delay(500);
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The treasure chest is empty!{nl}Right-click on the map and look for the next spot!");
		dialog.UnHideNPC("ROKAS30_TREASUREBOX99");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

