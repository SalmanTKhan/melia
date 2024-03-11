//--- Melia Script -----------------------------------------------------------
// The Supply Soldier's Last Mission (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Soul of the Supply Officer.
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

[QuestScript(30266)]
public class Quest30266Script : QuestScript
{
	protected override void Load()
	{
		SetId(30266);
		SetName("The Supply Soldier's Last Mission (2)");
		SetDescription("Talk with the Soul of the Supply Officer");

		AddPrerequisite(new LevelPrerequisite(300));
		AddPrerequisite(new CompletedPrerequisite("KATYN_18_RE_SQ_1"));

		AddObjective("collect0", "Collect 15 Lost Wall Supplies(s)", new CollectItemObjective("KATYN_18_RE_SQ_1_ITEM", 15));
		AddDrop("KATYN_18_RE_SQ_1_ITEM", 10f, 58504, 58505, 58506, 58507);

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 13800));

		AddDialogHook("KATYN_18_RE_SQ_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_18_RE_SQ_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_18_RE_SQ_2_select", "KATYN_18_RE_SQ_2", "I will retrieve the supplies from the monsters.", "Can't you just be content with that?"))
		{
			case 1:
				await dialog.Msg("KATYN_18_RE_SQ_2_agree");
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

		if (character.Inventory.HasItem("KATYN_18_RE_SQ_1_ITEM", 15))
		{
			character.Inventory.RemoveItem("KATYN_18_RE_SQ_1_ITEM", 15);
			await dialog.Msg("KATYN_18_RE_SQ_2_succ");
			dialog.HideNPC("KATYN_18_RE_SQ_NPC_1");
			await dialog.Msg("FadeOutIN/1000");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

