//--- Melia Script -----------------------------------------------------------
// There Is No Concrete Evidence
//--- Description -----------------------------------------------------------
// Quest to Talk with Jaunius.
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

[QuestScript(90084)]
public class Quest90084Script : QuestScript
{
	protected override void Load()
	{
		SetId(90084);
		SetName("There Is No Concrete Evidence");
		SetDescription("Talk with Jaunius");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_25_4_SQ_10"));

		AddObjective("collect0", "Collect 8 Pag Clamper's Core(s)", new CollectItemObjective("CATACOMB_25_4_SQ_20_ITEM", 8));
		AddDrop("CATACOMB_25_4_SQ_20_ITEM", 9f, "Pagclamper_yellow");

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("CATACOMB_25_4_SQ_JAUNIUS1", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_25_4_SQ_JAUNIUS1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_25_4_SQ_20_ST", "CATACOMB_25_4_SQ_20", "What is the link between the divine energy and monster core?", "I will think about it"))
		{
			case 1:
				await dialog.Msg("CATACOMB_25_4_SQ_20_AG");
				await dialog.Msg("BalloonText/CATACOMB_25_4_SQ_20_AG2/7");
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

		if (character.Inventory.HasItem("CATACOMB_25_4_SQ_20_ITEM", 8))
		{
			character.Inventory.RemoveItem("CATACOMB_25_4_SQ_20_ITEM", 8);
			await dialog.Msg("CATACOMB_25_4_SQ_20_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

