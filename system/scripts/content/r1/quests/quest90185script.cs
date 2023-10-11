//--- Melia Script -----------------------------------------------------------
// The Great Problem-Solver (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Baron Munchausen.
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

[QuestScript(90185)]
public class Quest90185Script : QuestScript
{
	protected override void Load()
	{
		SetId(90185);
		SetName("The Great Problem-Solver (3)");
		SetDescription("Talk to Baron Munchausen");

		AddPrerequisite(new LevelPrerequisite(290));
		AddPrerequisite(new CompletedPrerequisite("LOWLV_BOASTER_SQ_20"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("misc_ore17", 2));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("LOWLV_BOASTER_MUENCHHAUSEN", "BeforeStart", BeforeStart);
		AddDialogHook("LOWLV_BOASTER_MUENCHHAUSEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LOWLV_BOASTER_SQ_30_ST", "LOWLV_BOASTER_SQ_30", "What's the problem?", "I'm not interested"))
		{
			case 1:
				await dialog.Msg("LOWLV_BOASTER_SQ_30_AG");
				dialog.UnHideNPC("LOWLV_BOASTER_SQ_30");
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

		if (character.Inventory.HasItem("LOWLV_BOASTER_SQ_30_ITEM", 6))
		{
			character.Inventory.RemoveItem("LOWLV_BOASTER_SQ_30_ITEM", 6);
			await dialog.Msg("LOWLV_BOASTER_SQ_30_SU");
			dialog.HideNPC("LOWLV_BOASTER_SQ_30");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

