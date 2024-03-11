//--- Melia Script -----------------------------------------------------------
// To a Safe Place
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Ausrine.
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

[QuestScript(91199)]
public class Quest91199Script : QuestScript
{
	protected override void Load()
	{
		SetId(91199);
		SetName("To a Safe Place");
		SetDescription("Talk to Goddess Ausrine");

		AddPrerequisite(new LevelPrerequisite(490));
		AddPrerequisite(new CompletedPrerequisite("EP15_2_D_NICOPOLIS_1_MQ_2"));

		AddObjective("kill0", "Kill 10 Papillon Soldier(s) or Papillon Assassin(s)", new KillObjective(10, 59805, 59807));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("EP15_2_D_NICO_AUSIRINE_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_2_D_NICO_AUSIRINE_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_2_D_NICOPOLIS_1_MQ_3_DLG1", "EP15_2_D_NICOPOLIS_1_MQ_3", "Leave it to me.", "I'm not ready."))
		{
			case 1:
				// Func/SCR_EP15_2_DNICO_AUSIRINE_1_AFTER;
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

		await dialog.Msg("EP15_2_D_NICOPOLIS_1_MQ_3_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

