//--- Melia Script -----------------------------------------------------------
// Different Circumstances (9)
//--- Description -----------------------------------------------------------
// Quest to Talk to Tadas.
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

[QuestScript(60419)]
public class Quest60419Script : QuestScript
{
	protected override void Load()
	{
		SetId(60419);
		SetName("Different Circumstances (9)");
		SetDescription("Talk to Tadas");

		AddPrerequisite(new LevelPrerequisite(401));
		AddPrerequisite(new CompletedPrerequisite("CASTLE96_MQ_8"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE96_MQ_TADAS_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE96_MQ_TADAS_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE96_MQ_9_1", "CASTLE96_MQ_9", "What does that mean?", "Why all the fuss?"))
		{
			case 1:
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

		await dialog.Msg("CASTLE96_MQ_9_3");
		await dialog.Msg("FadeOutIN/2000");
		dialog.HideNPC("CASTLE96_MQ_WOLKE_NPC");
		dialog.HideNPC("CASTLE96_MQ_NERGUI_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

