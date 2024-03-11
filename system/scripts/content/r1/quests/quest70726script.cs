//--- Melia Script -----------------------------------------------------------
// The Cause of All This
//--- Description -----------------------------------------------------------
// Quest to Talk with Alchemist Sophia.
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

[QuestScript(70726)]
public class Quest70726Script : QuestScript
{
	protected override void Load()
	{
		SetId(70726);
		SetName("The Cause of All This");
		SetDescription("Talk with Alchemist Sophia");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN42_2_SQ06"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("BRACKEN422_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN422_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN422_SQ_07_start", "BRACKEN42_2_SQ07", "What is the final thing to do?", "You will hear from my lawyer."))
		{
			case 1:
				await dialog.Msg("BRACKEN422_SQ_07_agree");
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

		if (character.Inventory.HasItem("BRACKEN42_2_SQ07_ITEM", 9))
		{
			character.Inventory.RemoveItem("BRACKEN42_2_SQ07_ITEM", 9);
			await dialog.Msg("BRACKEN422_SQ_07_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

