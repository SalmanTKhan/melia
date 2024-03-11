//--- Melia Script -----------------------------------------------------------
// Something's Bugging You, Scout? (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Soul of the Scout.
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

[QuestScript(30270)]
public class Quest30270Script : QuestScript
{
	protected override void Load()
	{
		SetId(30270);
		SetName("Something's Bugging You, Scout? (1)");
		SetDescription("Talk with the Soul of the Scout");

		AddPrerequisite(new LevelPrerequisite(300));

		AddObjective("collect0", "Collect 1 Scout Report", new CollectItemObjective("KATYN_18_RE_SQ_6_ITEM", 1));
		AddDrop("KATYN_18_RE_SQ_6_ITEM", 1f, 58504, 58505, 58506, 58507);

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 13800));

		AddDialogHook("KATYN_18_RE_SQ_NPC_3", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_18_RE_SQ_NPC_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_18_RE_SQ_6_select", "KATYN_18_RE_SQ_6", "I will find that report.", "Think about it further."))
		{
			case 1:
				await dialog.Msg("KATYN_18_RE_SQ_6_agree");
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

		if (character.Inventory.HasItem("KATYN_18_RE_SQ_6_ITEM", 1))
		{
			character.Inventory.RemoveItem("KATYN_18_RE_SQ_6_ITEM", 1);
			await dialog.Msg("KATYN_18_RE_SQ_6_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

