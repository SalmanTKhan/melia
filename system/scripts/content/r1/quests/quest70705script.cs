//--- Melia Script -----------------------------------------------------------
// Dig up the relics
//--- Description -----------------------------------------------------------
// Quest to Talk to the soul of Victoras.
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

[QuestScript(70705)]
public class Quest70705Script : QuestScript
{
	protected override void Load()
	{
		SetId(70705);
		SetName("Dig up the relics");
		SetDescription("Talk to the soul of Victoras");

		AddPrerequisite(new LevelPrerequisite(278));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN42_1_SQ05"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11398));

		AddDialogHook("BRACKEN421_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN421_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN421_SQ_06_start", "BRACKEN42_1_SQ06", "How do I check the bracken pile?", "About what happpened", "Argh, brackens my only weakness."))
		{
			case 1:
				await dialog.Msg("BRACKEN421_SQ_06_agree");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("BRACKEN421_SQ_06_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("BRACKEN42_1_SQ06_ITEM", 1))
		{
			character.Inventory.RemoveItem("BRACKEN42_1_SQ06_ITEM", 1);
			await dialog.Msg("BRACKEN421_SQ_06_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

