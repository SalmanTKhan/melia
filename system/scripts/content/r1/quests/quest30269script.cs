//--- Melia Script -----------------------------------------------------------
// Castle Wall Soldier's Unfinished Business (3)
//--- Description -----------------------------------------------------------
// Quest to Place the keepsakes in the middle of the sanctuary.
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

[QuestScript(30269)]
public class Quest30269Script : QuestScript
{
	protected override void Load()
	{
		SetId(30269);
		SetName("Castle Wall Soldier's Unfinished Business (3)");
		SetDescription("Place the keepsakes in the middle of the sanctuary");

		AddPrerequisite(new LevelPrerequisite(300));
		AddPrerequisite(new CompletedPrerequisite("KATYN_18_RE_SQ_4"));
		AddPrerequisite(new ItemPrerequisite("KATYN_18_RE_SQ_3_ITEM", -100));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 13800));

		AddDialogHook("KATYN_18_RE_SQ_OBJ_3", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_18_RE_SQ_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("KATYN_18_RE_SQ_5_succ");
		dialog.HideNPC("KATYN_18_RE_SQ_NPC_2");
		await dialog.Msg("FadeOutIN/1000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

