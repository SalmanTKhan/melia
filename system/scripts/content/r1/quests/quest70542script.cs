//--- Melia Script -----------------------------------------------------------
// Maven Abbey Rosary
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim David.
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

[QuestScript(70542)]
public class Quest70542Script : QuestScript
{
	protected override void Load()
	{
		SetId(70542);
		SetName("Maven Abbey Rosary");
		SetDescription("Talk to Pilgrim David");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_4_SQ02"));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10865));

		AddDialogHook("PILGRIM414_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM414_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM414_SQ_03_start", "PILGRIM41_4_SQ03", "Say that there must be something to prove", "Say that you don't know if there is anything that can help"))
		{
			case 1:
				await dialog.Msg("PILGRIM414_SQ_03_agree");
				await dialog.Msg("BalloonText/PILGRIM414_SQ_03_DLG/5");
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

		if (character.Inventory.HasItem("PILGRIM41_4_SQ03_ITEM", 1))
		{
			character.Inventory.RemoveItem("PILGRIM41_4_SQ03_ITEM", 1);
			await dialog.Msg("PILGRIM414_SQ_03_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

