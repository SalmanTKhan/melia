//--- Melia Script -----------------------------------------------------------
// Giltine's Rival (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon King Baiga.
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

[QuestScript(80448)]
public class Quest80448Script : QuestScript
{
	protected override void Load()
	{
		SetId(80448);
		SetName("Giltine's Rival (2)");
		SetDescription("Talk to Demon King Baiga");

		AddPrerequisite(new LevelPrerequisite(421));
		AddPrerequisite(new CompletedPrerequisite("D_CASTLE_19_1_MQ_06"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));

		AddDialogHook("D_CASTLE_19_1_MQ_07_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("D_CASTLE_19_1_MQ_04_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("D_CASTLE_19_1_MQ_07_ST", "D_CASTLE_19_1_MQ_07", "Ask what offer it is.", "Sorry, I'll have to refuse."))
		{
			case 1:
				await dialog.Msg("D_CASTLE_19_1_MQ_07_AFST");
				dialog.HideNPC("D_CASTLE_19_1_MQ_07_NPC");
				await dialog.Msg("FadeOutIN/2000");
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

		await dialog.Msg("D_CASTLE_19_1_MQ_07_SU");
		dialog.HideNPC("D_CASTLE_19_1_MQ_04_NPC");
		await dialog.Msg("FadeOutIN/2000");
		dialog.UnHideNPC("F_CASTLE_97_MQ_01_NPC");
		dialog.UnHideNPC("F_CASTLE_97_MQ_01_NPC2");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

