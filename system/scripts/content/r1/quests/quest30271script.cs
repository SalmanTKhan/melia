//--- Melia Script -----------------------------------------------------------
// Something's Bugging You, Scout? (2)
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

[QuestScript(30271)]
public class Quest30271Script : QuestScript
{
	protected override void Load()
	{
		SetId(30271);
		SetName("Something's Bugging You, Scout? (2)");
		SetDescription("Talk with the Soul of the Scout");

		AddPrerequisite(new LevelPrerequisite(300));
		AddPrerequisite(new CompletedPrerequisite("KATYN_18_RE_SQ_6"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 13800));

		AddDialogHook("KATYN_18_RE_SQ_NPC_3", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_18_RE_SQ_NPC_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_18_RE_SQ_7_select", "KATYN_18_RE_SQ_7", "Let's do it.", "It's too dangerous."))
		{
			case 1:
				await dialog.Msg("KATYN_18_RE_SQ_7_agree");
				dialog.UnHideNPC("KATYN_18_RE_SQ_OBJ_4");
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

		if (character.Inventory.HasItem("KATYN_18_RE_SQ_7_ITEM", 6))
		{
			character.Inventory.RemoveItem("KATYN_18_RE_SQ_7_ITEM", 6);
			await dialog.Msg("KATYN_18_RE_SQ_7_succ");
			dialog.HideNPC("KATYN_18_RE_SQ_OBJ_4");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

