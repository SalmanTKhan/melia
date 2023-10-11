//--- Melia Script -----------------------------------------------------------
// The Enemy's Smell
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Erra.
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

[QuestScript(50030)]
public class Quest50030Script : QuestScript
{
	protected override void Load()
	{
		SetId(50030);
		SetName("The Enemy's Smell");
		SetDescription("Talk to Watcher Erra");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PARTY_Q_020_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(100));

		AddObjective("collect0", "Collect 1 Moa Lump", new CollectItemObjective("PARTY_Q2_MOA_ITEM", 1));
		AddDrop("PARTY_Q2_MOA_ITEM", 10f, "boss_moa_Q2");

		AddDialogHook("GELE574_ERRA", "BeforeStart", BeforeStart);
		AddDialogHook("GELE574_ERRA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PARTY_Q_020_startnpc01", "PARTY_Q_020", "I will help the task", "Tell him to work hard"))
		{
			case 1:
				await dialog.Msg("PARTY_Q_020_startnpc02");
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

		if (character.Inventory.HasItem("PARTY_Q2_MOA_ITEM", 1))
		{
			character.Inventory.RemoveItem("PARTY_Q2_MOA_ITEM", 1);
			await dialog.Msg("PARTY_Q_020_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

