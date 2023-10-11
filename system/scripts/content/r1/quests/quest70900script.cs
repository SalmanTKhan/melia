//--- Melia Script -----------------------------------------------------------
// The Relics of the Ancient
//--- Description -----------------------------------------------------------
// Quest to Talk with Investigation Team Head Ella.
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

[QuestScript(70900)]
public class Quest70900Script : QuestScript
{
	protected override void Load()
	{
		SetId(70900);
		SetName("The Relics of the Ancient");
		SetDescription("Talk with Investigation Team Head Ella");

		AddPrerequisite(new LevelPrerequisite(303));

		AddReward(new ItemReward("Vis", 5200));

		AddDialogHook("DCAPITAL103_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL103_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL103_SQ_01_start", "DCAPITAL103_SQ01", "What needs to be done?", "About her mission", "There is some other goal, so, I can't be with you on this one."))
		{
			case 1:
				await dialog.Msg("DCAPITAL103_SQ_01_agree");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("DCAPITAL103_SQ_01_select");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("DCAPITAL103_SQ01_ITEM", 12))
		{
			character.Inventory.RemoveItem("DCAPITAL103_SQ01_ITEM", 12);
			await dialog.Msg("DCAPITAL103_SQ_01_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

