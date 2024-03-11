//--- Melia Script -----------------------------------------------------------
// The Clown from the Closing Show
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(60278)]
public class Quest60278Script : QuestScript
{
	protected override void Load()
	{
		SetId(60278);
		SetName("The Clown from the Closing Show");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new LevelPrerequisite(347));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB485_MQ_6"));

		AddReward(new ExpReward(41922528, 41922528));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 106));

		AddDialogHook("FLIBRARY485_NERINGA_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY484_VIVORA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB485_MQ_7_1", "FANTASYLIB485_MQ_7", "I will pass this along.", "I need to prepare myself"))
		{
			case 1:
				dialog.HideNPC("FLIBRARY485_NERINGA_NPC_2");
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

		await dialog.Msg("FANTASYLIB485_MQ_7_3");
		character.PlayEffectLocal("F_wizard_samsara_light");
		character.PlayEffectLocal("F_light119_yellow");
		await dialog.Msg("FANTASYLIB485_MQ_7_4");
		dialog.HideNPC("FLIBRARY484_VIVORA_NPC");
		await dialog.Msg("FadeOutIN/3000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

