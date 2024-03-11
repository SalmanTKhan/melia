//--- Melia Script -----------------------------------------------------------
// The Last Elder
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Commander Byle.
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

[QuestScript(72207)]
public class Quest72207Script : QuestScript
{
	protected override void Load()
	{
		SetId(72207);
		SetName("The Last Elder");
		SetDescription("Talk to Resistance Commander Byle");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "STARTOWER_91_MQ_90_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(382));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_91_MQ_80"));

		AddObjective("collect0", "Collect 1 Elder Cezaris' Key", new CollectItemObjective("STARTOWER_91_MQ_90_ITEM02", 1));
		AddDrop("STARTOWER_91_MQ_90_ITEM02", 10f, "boss_Trampler_Q1");

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 20246));

		AddDialogHook("D_STARTOWER_91_RESISTANCE_LEADER_BAYL_02", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_91_RESISTANCE_LEADER_BAYL_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_91_MQ_90_DLG1", "STARTOWER_91_MQ_90", "Alright", "I need to prepare myself"))
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

		if (character.Inventory.HasItem("STARTOWER_91_MQ_90_ITEM02", 1))
		{
			character.Inventory.RemoveItem("STARTOWER_91_MQ_90_ITEM02", 1);
			//SCR_STARTOWER_91_MQ_90_END
			await dialog.Msg("STARTOWER_91_MQ_90_DLG3");
			await dialog.Msg("FadeOutIN/1000");
			dialog.HideNPC("D_STARTOWER_91_RESISTANCE_LEADER_BAYL_02");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

