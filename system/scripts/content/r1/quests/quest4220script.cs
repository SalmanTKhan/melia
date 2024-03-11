//--- Melia Script -----------------------------------------------------------
// Crystal Wall of the Closed Area
//--- Description -----------------------------------------------------------
// Quest to Check the Crystal Pillar in the Closed Area.
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

[QuestScript(4220)]
public class Quest4220Script : QuestScript
{
	protected override void Load()
	{
		SetId(4220);
		SetName("Crystal Wall of the Closed Area");
		SetDescription("Check the Crystal Pillar in the Closed Area");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "ACT4_MINE3_ENTER_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(21));
		AddPrerequisite(new CompletedPrerequisite("MINE_3_RESQUE1"));

		AddObjective("collect0", "Collect 5 Vubbe Magic Stone(s)", new CollectItemObjective("D_Bube_Mane", 5));
		AddDrop("D_Bube_Mane", 10f, 47456, 400209);

		AddReward(new ExpReward(10744, 10744));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 294));

		AddDialogHook("CMINE3_BOSSROOM_OPEN", "BeforeStart", BeforeStart);
		AddDialogHook("CMINE3_BOSSROOM_OPEN", "BeforeEnd", BeforeEnd);
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

		if (character.Inventory.HasItem("D_Bube_Mane", 5))
		{
			character.Inventory.RemoveItem("D_Bube_Mane", 5);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The barrier stone that is blocking the closed area is collapsing!");
			dialog.HideNPC("CMINE3_BOSSROOM_OPEN");
			dialog.UnHideNPC("WS_ACT4_3_ACT4_BOSS");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

