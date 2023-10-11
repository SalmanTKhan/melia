//--- Melia Script -----------------------------------------------------------
// Well, That's Something
//--- Description -----------------------------------------------------------
// Quest to Talk with Alchemist Sophia.
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

[QuestScript(70723)]
public class Quest70723Script : QuestScript
{
	protected override void Load()
	{
		SetId(70723);
		SetName("Well, That's Something");
		SetDescription("Talk with Alchemist Sophia");

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN42_2_SQ03"));

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

		switch (await dialog.Select("BRACKEN422_SQ_04_start", "BRACKEN42_2_SQ04", "How about we enhance the moglan?", "There is no way. Just give it up."))
		{
			case 1:
				await dialog.Msg("BRACKEN422_SQ_04_agree");
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

		if (character.Inventory.HasItem("BRACKEN42_2_SQ04_ITEM", 15))
		{
			character.Inventory.RemoveItem("BRACKEN42_2_SQ04_ITEM", 15);
			await dialog.Msg("BRACKEN422_SQ_04_succ");
			await dialog.Msg("NPCAin/BRACKEN422_SQ_01/SKL_TINCTURING_FILTER2/0");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

