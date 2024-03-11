//--- Melia Script -----------------------------------------------------------
// Alembique Tales(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kedora Alliance Merchant Alta.
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

[QuestScript(60210)]
public class Quest60210Script : QuestScript
{
	protected override void Load()
	{
		SetId(60210);
		SetName("Alembique Tales(1)");
		SetDescription("Talk to Kedora Alliance Merchant Alta");

		AddPrerequisite(new LevelPrerequisite(320));

		AddDialogHook("LSCAVE551_ALTAR_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("LSCAVE551_HELANDA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LSCAVE551_SQ_1_1", "LSCAVE551_SQ_1", "Tell me what happened and I will help you.", "I'll find it myself"))
		{
			case 1:
				dialog.UnHideNPC("LSCAVE551_HELANDA_NPC");
				await dialog.Msg("LSCAVE551_SQ_1_1_1");
				dialog.UnHideNPC("LSCAVE551_ALTAR_NPC");
				character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
				await dialog.Msg("LSCAVE551_SQ_1_ST1");
				await dialog.Msg("왜 못들어가느냐고 묻는다");
				character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
				await dialog.Msg("LSCAVE551_SQ_1_ST2");
				await dialog.Msg("용병단은 왜 꾸린 건지 물어본다");
				await dialog.Msg("LSCAVE551_SQ_1_ST3");
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

		await dialog.Msg("LSCAVE551_SQ_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

