//--- Melia Script -----------------------------------------------------------
// I Can Hear You Singing (9)
//--- Description -----------------------------------------------------------
// Quest to Talk to Indrea.
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

[QuestScript(50370)]
public class Quest50370Script : QuestScript
{
	protected override void Load()
	{
		SetId(50370);
		SetName("I Can Hear You Singing (9)");
		SetDescription("Talk to Indrea");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WTREES22_1_SQ8_AFTER_TRACK", "track");

		AddPrerequisite(new LevelPrerequisite(344));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_1_SQ8"));

		AddDialogHook("WTREES221_SUBQ_NPC4", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES221_SUBQ_NPC4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_1_SUBQ9_1_START1", "WTREES22_1_SQ9_1"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("WTREES22_1_SUBQ8_ITEM1", 1))
		{
			character.Inventory.RemoveItem("WTREES22_1_SUBQ8_ITEM1", 1);
			await dialog.Msg("WTREES22_1_SUBQ9_1_SUCC1");
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Follow Indrea to Dainuoti Lot.");
			dialog.HideNPC("WTREES221_SUBQ_NPC4");
			dialog.UnHideNPC("WTREES221_SUBQ_NPC5");
			await dialog.Msg("FadeOutIN/1000");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

