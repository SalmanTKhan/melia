//--- Melia Script -----------------------------------------------------------
// Preventive Measures (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Tara Miles.
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

[QuestScript(8461)]
public class Quest8461Script : QuestScript
{
	protected override void Load()
	{
		SetId(8461);
		SetName("Preventive Measures (1)");
		SetDescription("Talk to Tara Miles");

		AddPrerequisite(new LevelPrerequisite(107));

		AddObjective("kill0", "Kill 10 Cockatrice(s)", new KillObjective(10, MonsterId.Cockatries));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("REMAINS_40_TARA_01", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS_40_TARA_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS40_SQ_03_01", "REMAINS40_SQ_03", "I can help you", "Decline"))
		{
			case 1:
				await dialog.Msg("REMAINS40_SQ_03_AG");
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

		await dialog.Msg("REMAINS40_SQ_03_03");
		await dialog.Msg("FadeOutIN/2500");
		dialog.HideNPC("REMAINS_40_TARA_01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

