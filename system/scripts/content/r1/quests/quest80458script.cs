//--- Melia Script -----------------------------------------------------------
// Root of the Divine Tree (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Austeja.
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

[QuestScript(80458)]
public class Quest80458Script : QuestScript
{
	protected override void Load()
	{
		SetId(80458);
		SetName("Root of the Divine Tree (5)");
		SetDescription("Talk to Goddess Austeja");

		AddPrerequisite(new LevelPrerequisite(431));
		AddPrerequisite(new CompletedPrerequisite("F_CASTLE_99_MQ_04"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));
		AddReward(new ItemReward("Vis", 24998));

		AddDialogHook("F_CASTLE_99_MQ_05_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_CASTLE_99_MQ_06_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_CASTLE_99_MQ_05_ST", "F_CASTLE_99_MQ_05", "We should get a move on.", "Say it's too late."))
		{
			case 1:
				await dialog.Msg("F_CASTLE_99_MQ_05_AFST");
				dialog.HideNPC("F_CASTLE_99_MQ_05_NPC");
				dialog.UnHideNPC("F_CASTLE_99_MQ_05_OBJ_1");
				await dialog.Msg("FadeOutIN/2000");
				// Func/F_CASTLE_99_MQ_05_START_RUN;
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

		await dialog.Msg("F_CASTLE_99_MQ_05_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

