//--- Melia Script -----------------------------------------------------------
// The Power of Altar
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

[QuestScript(90085)]
public class Quest90085Script : QuestScript
{
	protected override void Load()
	{
		SetId(90085);
		SetName("The Power of Altar");
		SetDescription("Talk with Jaunius");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_25_4_SQ_20"));

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

		switch (await dialog.Select("CATACOMB_25_4_SQ_30_ST", "CATACOMB_25_4_SQ_30", "What's the relationship between the keepsake and the divine energy?", "I can't do it."))
		{
			case 1:
				await dialog.Msg("CATACOMB_25_4_SQ_30_AG");
				await dialog.Msg("BalloonText/CATACOMB_25_4_SQ_30_AG2/7");
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

		if (character.Inventory.HasItem("CATACOMB_25_4_SQ_30_ITEM", 6))
		{
			character.Inventory.RemoveItem("CATACOMB_25_4_SQ_30_ITEM", 6);
			await dialog.Msg("CATACOMB_25_4_SQ_30_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_25_4_SQ_40");
	}
}

