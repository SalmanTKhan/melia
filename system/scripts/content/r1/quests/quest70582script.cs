//--- Melia Script -----------------------------------------------------------
// Those that take the wrong path
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70582)]
public class Quest70582Script : QuestScript
{
	protected override void Load()
	{
		SetId(70582);
		SetName("Those that take the wrong path");
		SetDescription("Talk to Monk Stella");

		AddPrerequisite(new LevelPrerequisite(271));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_5_SQ02"));

		AddDialogHook("PILGRIM415_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM415_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM415_SQ_03_start", "PILGRIM41_5_SQ03", "Ask if there is a way to destroy the Device", "Say that it is suspicious if it will be there"))
		{
			case 1:
				await dialog.Msg("PILGRIM415_SQ_03_agree");
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

		if (character.Inventory.HasItem("PILGRIM41_5_SQ02_2_ITEM", 1))
		{
			character.Inventory.RemoveItem("PILGRIM41_5_SQ02_2_ITEM", 1);
			character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
			await dialog.Msg("PILGRIM415_SQ_03_succ1");
			await dialog.Msg("자신 역시 수도사 스텔라의 부탁을 받았다고 한다");
			await dialog.Msg("PILGRIM415_SQ_03_succ2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

