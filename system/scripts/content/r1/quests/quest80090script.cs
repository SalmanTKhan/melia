//--- Melia Script -----------------------------------------------------------
// Hungry Faith (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Elgos Monk.
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

[QuestScript(80090)]
public class Quest80090Script : QuestScript
{
	protected override void Load()
	{
		SetId(80090);
		SetName("Hungry Faith (1)");
		SetDescription("Talk to Elgos Monk");

		AddPrerequisite(new LevelPrerequisite(232));
		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_4_SQ_1"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 63));
		AddReward(new ItemReward("Vis", 8352));

		AddDialogHook("ABBEY_35_4_MONK", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_4_MONK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY_35_4_SQ_2_start", "ABBEY_35_4_SQ_2", "I'm not a member of the Order of the Tree of Truth", "Leave it for now"))
		{
			case 1:
				await dialog.Msg("ABBEY_35_4_SQ_2_agree");
				await dialog.Msg("BalloonText/ABBEY_35_4_SQ_2_STUN/8");
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

		if (character.Inventory.HasItem("ABBEY_35_4_SQ_2_FOOD", 1))
		{
			character.Inventory.RemoveItem("ABBEY_35_4_SQ_2_FOOD", 1);
			await Task.Delay(1000);
			await dialog.Msg("ABBEY_35_4_SQ_2_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

