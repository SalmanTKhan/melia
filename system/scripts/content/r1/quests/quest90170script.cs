//--- Melia Script -----------------------------------------------------------
// Suspicious Movement (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Linker Master.
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

[QuestScript(90170)]
public class Quest90170Script : QuestScript
{
	protected override void Load()
	{
		SetId(90170);
		SetName("Suspicious Movement (1)");
		SetDescription("Talk to the Linker Master");

		AddPrerequisite(new LevelPrerequisite(290));

		AddObjective("kill0", "Kill 2 Yellow Gazing Golem(s)", new KillObjective(2, MonsterId.Gazing_Golem_Yellow_Q1));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("misc_ore17", 1));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("JOB_2_LINKER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_LINKER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LOWLV_EYEOFBAIGA_SQ_10_ST", "LOWLV_EYEOFBAIGA_SQ_10", "I'll help you", "I am not particularly interested."))
		{
			case 1:
				await dialog.Msg("LOWLV_EYEOFBAIGA_SQ_10_AG");
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

		await dialog.Msg("LOWLV_EYEOFBAIGA_SQ_10_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

