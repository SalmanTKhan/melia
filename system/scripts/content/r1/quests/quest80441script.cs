//--- Melia Script -----------------------------------------------------------
// Frienel Memorial Kupole
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Maya.
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

[QuestScript(80441)]
public class Quest80441Script : QuestScript
{
	protected override void Load()
	{
		SetId(80441);
		SetName("Frienel Memorial Kupole");
		SetDescription("Talk to Kupole Maya");

		AddPrerequisite(new LevelPrerequisite(421));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));

		AddDialogHook("D_CASTLE_19_1_MQ_PRE_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("D_CASTLE_19_1_MQ_PRE_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("D_CASTLE_19_1_MQ_PRE_ST", "D_CASTLE_19_1_MQ_PRE", "Ask what's going on.", "Ignore."))
		{
			case 1:
				await dialog.Msg("D_CASTLE_19_1_MQ_PRE_AFST");
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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

		await dialog.Msg("D_CASTLE_19_1_MQ_PRE_SU");
		dialog.HideNPC("D_CASTLE_19_1_MQ_PRE_NPC");
		await dialog.Msg("FadeOutIN/2000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

