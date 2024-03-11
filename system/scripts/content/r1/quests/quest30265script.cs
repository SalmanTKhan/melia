//--- Melia Script -----------------------------------------------------------
// The Supply Soldier's Last Mission (1)
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

[QuestScript(30265)]
public class Quest30265Script : QuestScript
{
	protected override void Load()
	{
		SetId(30265);
		SetName("The Supply Soldier's Last Mission (1)");
		SetDescription("Talk with the Soul of the Supply Officer");

		AddPrerequisite(new LevelPrerequisite(300));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 13800));

		AddDialogHook("KATYN_18_RE_SQ_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_18_RE_SQ_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_18_RE_SQ_1_select", "KATYN_18_RE_SQ_1", "I will gather the supples.", "A pointless and meaningless task, it sounds like."))
		{
			case 1:
				await dialog.Msg("KATYN_18_RE_SQ_1_agree");
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

		if (character.Inventory.HasItem("KATYN_18_RE_SQ_1_ITEM", 6))
		{
			character.Inventory.RemoveItem("KATYN_18_RE_SQ_1_ITEM", 6);
			await dialog.Msg("KATYN_18_RE_SQ_1_succ");
			dialog.HideNPC("KATYN_18_RE_SQ_OBJ_1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

