//--- Melia Script -----------------------------------------------------------
// The Light through Darkness
//--- Description -----------------------------------------------------------
// Quest to Talk to Investigator Horatio.
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

[QuestScript(70911)]
public class Quest70911Script : QuestScript
{
	protected override void Load()
	{
		SetId(70911);
		SetName("The Light through Darkness");
		SetDescription("Talk to Investigator Horatio");

		AddPrerequisite(new LevelPrerequisite(303));

		AddReward(new ExpReward(12101740, 12101740));
		AddReward(new ItemReward("expCard13", 1));
		AddReward(new ItemReward("Vis", 13938));

		AddDialogHook("DCAPITAL103_SQ_11", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL103_SQ_11", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL103_SQ_12_start", "DCAPITAL103_SQ12", "Leave it to me", "Hmm... can you sweeten the deal for me a bit?"))
		{
			case 1:
				await dialog.Msg("DCAPITAL103_SQ_12_agree");
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

		if (character.Inventory.HasItem("DCAPITAL103_SQ12_ITEM", 8))
		{
			character.Inventory.RemoveItem("DCAPITAL103_SQ12_ITEM", 8);
			await dialog.Msg("DCAPITAL103_SQ_12_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

