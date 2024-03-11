//--- Melia Script -----------------------------------------------------------
// Why on Medzio Diena... (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Liepa.
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

[QuestScript(30241)]
public class Quest30241Script : QuestScript
{
	protected override void Load()
	{
		SetId(30241);
		SetName("Why on Medzio Diena... (1)");
		SetDescription("Talk to Kupole Liepa");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_2_SQ_10"));
		AddPrerequisite(new ItemPrerequisite("CASTLE_20_2_SQ_3_ITEM", -100), new ItemPrerequisite("CASTLE_20_2_SQ_4_ITEM", -100), new ItemPrerequisite("CASTLE_20_2_SQ_10_ITEM_1", -100));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("CASTLE_20_2_NPC_1_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE_20_2_NPC_1_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE_20_2_SQ_11_select", "CASTLE_20_2_SQ_11", "Show the clue note", "I need to investigate further."))
		{
			case 1:
				await dialog.Msg("CASTLE_20_2_SQ_11_agree");
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

		await dialog.Msg("CASTLE_20_2_SQ_11_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

