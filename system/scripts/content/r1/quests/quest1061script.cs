//--- Melia Script -----------------------------------------------------------
// The Eternal Adventure (2)
//--- Description -----------------------------------------------------------
// Quest to Collect Varkis' Research Materials at Neck Cliff of Snake.
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

[QuestScript(1061)]
public class Quest1061Script : QuestScript
{
	protected override void Load()
	{
		SetId(1061);
		SetName("The Eternal Adventure (2)");
		SetDescription("Collect Varkis' Research Materials at Neck Cliff of Snake");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS29_VACYS4_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(73));
		AddPrerequisite(new CompletedPrerequisite("ROKAS29_VACYS3"));

		AddObjective("collect0", "Collect 1 Varkis' Research Materials (3)", new CollectItemObjective("ROKAS29_VACYS_ITEM_2", 1));
		AddDrop("ROKAS29_VACYS_ITEM_2", 10f, "boss_Unknocker_Q1");

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("misc_gemExpStone01", 1));
		AddReward(new ItemReward("Vis", 1387));

		AddDialogHook("ROKAS29_SLATE2", "BeforeStart", BeforeStart);
		AddDialogHook("VACYS_SOUL", "BeforeEnd", BeforeEnd);
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

		if (character.Inventory.HasItem("ROKAS29_VACYS_ITEM_2", 1))
		{
			character.Inventory.RemoveItem("ROKAS29_VACYS_ITEM_2", 1);
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "It is written that the next document is hidden at Apatinis Cliff");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

