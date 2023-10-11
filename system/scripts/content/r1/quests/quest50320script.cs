//--- Melia Script -----------------------------------------------------------
// I Can Hear You Singing (5)
//--- Description -----------------------------------------------------------
// Quest to Follow Indrea.
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

[QuestScript(50320)]
public class Quest50320Script : QuestScript
{
	protected override void Load()
	{
		SetId(50320);
		SetName("I Can Hear You Singing (5)");
		SetDescription("Follow Indrea");

		AddPrerequisite(new LevelPrerequisite(344));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_1_SQ4"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 16512));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("WTREES221_SUBQ_NPC3", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES221_SUBQ_NPC3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_1_SUBQ5_START1", "WTREES22_1_SQ5", "I'll go look for some raspberry juice.", "It'll be better if you look for it yourself."))
		{
			case 1:
				await dialog.Msg("WTREES22_1_SUBQ5_AGREE1");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("WTREES22_1_SUBQ5_ITEM4", 18))
		{
			character.Inventory.RemoveItem("WTREES22_1_SUBQ5_ITEM4", 18);
			await dialog.Msg("WTREES22_1_SUBQ5_SUCC1");
			character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Indrea is applying raspberry juice on some branches.");
			await dialog.Msg("NPCAin/WTREES221_SUBQ_NPC3/talk/0");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

