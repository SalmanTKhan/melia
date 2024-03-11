//--- Melia Script -----------------------------------------------------------
// Retrieve Holy Offer [Krivis Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Krivis Master.
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

[QuestScript(8743)]
public class Quest8743Script : QuestScript
{
	protected override void Load()
	{
		SetId(8743);
		SetName("Retrieve Holy Offer [Krivis Advancement]");
		SetDescription("Talk to the Krivis Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_KRIVI5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 1 Res Sacrae", new CollectItemObjective("JOB_KRIVI5_1_ITEM", 1));
		AddDrop("JOB_KRIVI5_1_ITEM", 10f, "boss_tutu");

		AddDialogHook("MASTER_KRIWI", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_KRIWI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_KRIVI5_1_01", "JOB_KRIVI5_1", "I'll get back the Holy offering from the town center", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_KRIVI5_1_AG");
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

		if (character.Inventory.HasItem("JOB_KRIVI5_1_ITEM", 1))
		{
			character.Inventory.RemoveItem("JOB_KRIVI5_1_ITEM", 1);
			await dialog.Msg("JOB_KRIVI5_1_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

