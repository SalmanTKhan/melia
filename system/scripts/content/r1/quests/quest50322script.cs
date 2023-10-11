//--- Melia Script -----------------------------------------------------------
// I Can Hear You Singing (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Indrea.
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

[QuestScript(50322)]
public class Quest50322Script : QuestScript
{
	protected override void Load()
	{
		SetId(50322);
		SetName("I Can Hear You Singing (7)");
		SetDescription("Talk to Indrea");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WTREES22_1_SQ7_TRACK", "track");

		AddPrerequisite(new LevelPrerequisite(344));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_1_SQ6"));

		AddDialogHook("WTREES221_SUBQ_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES221_SUBQ_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_1_SUBQ7_START1", "WTREES22_1_SQ7", "Let's observe the situation for now.", "Just go"))
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

		if (character.Inventory.HasItem("WTREES22_1_SUBQ7_ITEM1", 1))
		{
			character.Inventory.RemoveItem("WTREES22_1_SUBQ7_ITEM1", 1);
			await dialog.Msg("WTREES22_1_SUBQ7_SUCC1");
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Follow Indrea to Paslepti Lot.");
			dialog.HideNPC("WTREES221_SUBQ_NPC3");
			dialog.UnHideNPC("WTREES221_SUBQ_NPC4");
			await dialog.Msg("FadeOutIN/1000");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

