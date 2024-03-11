//--- Melia Script -----------------------------------------------------------
// Small Difference (4)
//--- Description -----------------------------------------------------------
// Quest to Talk with Grave Robber Stephonas.
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

[QuestScript(8840)]
public class Quest8840Script : QuestScript
{
	protected override void Load()
	{
		SetId(8840);
		SetName("Small Difference (4)");
		SetDescription("Talk with Grave Robber Stephonas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FLASH63_SQ_08_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(193));
		AddPrerequisite(new CompletedPrerequisite("FLASH63_SQ_07"));

		AddObjective("collect0", "Collect 1 Frosty Core", new CollectItemObjective("FLASH63_SQ_08_1_ITEM", 1));
		AddDrop("FLASH63_SQ_08_1_ITEM", 10f, "boss_stonefroster");

		AddReward(new ExpReward(713829, 713829));
		AddReward(new ItemReward("expCard10", 5));
		AddReward(new ItemReward("Vis", 5983));

		AddDialogHook("FLASH63_STEPONAS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH63_STEPONAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH63_SQ_08_01", "FLASH63_SQ_08", "I'll go there", "I'll wait a little bit"))
		{
			case 1:
				dialog.UnHideNPC("FLASH63_SQ_08_NPC");
				await dialog.Msg("FLASH63_SQ_08_02");
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

		if (character.Inventory.HasItem("FLASH63_SQ_08_1_ITEM", 1))
		{
			character.Inventory.RemoveItem("FLASH63_SQ_08_1_ITEM", 1);
			await dialog.Msg("FLASH63_SQ_08_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

