//--- Melia Script -----------------------------------------------------------
// Destroy Demon God's Crystal (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Ausrine.
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

[QuestScript(91200)]
public class Quest91200Script : QuestScript
{
	protected override void Load()
	{
		SetId(91200);
		SetName("Destroy Demon God's Crystal (1)");
		SetDescription("Talk to Goddess Ausrine");

		AddPrerequisite(new LevelPrerequisite(490));
		AddPrerequisite(new CompletedPrerequisite("EP15_2_D_NICOPOLIS_1_MQ_3"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("EP15_2_D_NICO_AUSIRINE_2", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_2_D_NICOPOLIS_1_MQ_4_CRYSTAL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_2_D_NICOPOLIS_1_MQ_4_DLG1", "EP15_2_D_NICOPOLIS_1_MQ_4", "I can help.", "I need to prepare something."))
		{
			case 1:
				await dialog.Msg("EP15_2_D_NICOPOLIS_1_MQ_4_DLG2");
				await dialog.Msg("FadeOutIN/1500");
				dialog.HideNPC("EP15_2_D_NICO_AUSIRINE_2");
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

		// Func/SCR_EP15_2_D_NICOPOLIS_1_MQ_4_TRACK;
		dialog.HideNPC("EP15_2_D_NICOPOLIS_1_MQ_4_CRYSTAL");
		// Func/SCR_EP15_2_D_NICOPOLIS_1_MQ_5_Balloontext;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_2_D_NICOPOLIS_1_MQ_5");
	}
}

