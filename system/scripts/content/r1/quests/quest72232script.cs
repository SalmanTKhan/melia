//--- Melia Script -----------------------------------------------------------
// Destroying the Obelisks (2)
//--- Description -----------------------------------------------------------
// Quest to Investigate the Obelisk in the Armory.
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

[QuestScript(72232)]
public class Quest72232Script : QuestScript
{
	protected override void Load()
	{
		SetId(72232);
		SetName("Destroying the Obelisks (2)");
		SetDescription("Investigate the Obelisk in the Armory");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "CASTLE95_MAIN03_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(398));
		AddPrerequisite(new CompletedPrerequisite("CASTLE95_MAIN02"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("Vis", 21041));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE95_OBELISK_01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE95_MAIN03_END", "BeforeEnd", BeforeEnd);
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

		dialog.HideNPC("CASTLE95_OBELISK_01");
		dialog.HideNPC("CASTLE95_OBELISK_04");
		dialog.UnHideNPC("CASTLE95_OBELISK_01_BROKEN");
		dialog.UnHideNPC("CASTLE95_OBELISK_04_BROKEN");
		// Func/SCR_CASTLE95_MAIN03_SUCCESS;
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Investigate the Training Grounds obelisk as instructed in Antanina's note!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

