//--- Melia Script -----------------------------------------------------------
// Their purpose is
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Lada about the next goal.
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

[QuestScript(91038)]
public class Quest91038Script : QuestScript
{
	protected override void Load()
	{
		SetId(91038);
		SetName("Their purpose is");
		SetDescription("Talk to Goddess Lada about the next goal");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP13_F_SIAULIAI_1_MQ_06_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_1_MQ_05"));

		AddObjective("collect0", "Collect 1 Crystal Piece of Liepsna Firebug", new CollectItemObjective("EP13_F_SIAULIAI_1_MQ_06_ITEM_01", 1));
		AddDrop("EP13_F_SIAULIAI_1_MQ_06_ITEM_01", 10f, "boss_liepsna_firebug");

		AddReward(new ExpReward(6014994432, 6014994432));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("EP13_F_SIAULIAI_1_MQ_LADA_3", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_2_MQ_LADA_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_1_MQ_06_DLG1", "EP13_F_SIAULIAI_1_MQ_06", "I will investigate Malkos Felled Area ", "My hands are tied at the moment."))
		{
			case 1:
				// Func/SCR_EP13_F_SIAULIAI_1_MQ_LADA_3_HIDE;
				dialog.UnHideNPC("EP13_F_SIAULIAI_2_MQ_LADA_1");
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

		if (character.Inventory.HasItem("EP13_F_SIAULIAI_1_MQ_06_ITEM_01", 1))
		{
			character.Inventory.RemoveItem("EP13_F_SIAULIAI_1_MQ_06_ITEM_01", 1);
			await dialog.Msg("EP13_F_SIAULIAI_1_MQ_06_DLG2");
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			// Func/SCR_NEXTQUEST_LEVEL_CHECK/EP13_F_SIAULIAI_2_MQ_01;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

