//--- Melia Script -----------------------------------------------------------
// To the Fortress of the Land
//--- Description -----------------------------------------------------------
// Quest to Talk to Wilhelmina Carriot.
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

[QuestScript(50259)]
public class Quest50259Script : QuestScript
{
	protected override void Load()
	{
		SetId(50259);
		SetName("To the Fortress of the Land");
		SetDescription("Talk to Wilhelmina Carriot");

		AddPrerequisite(new LevelPrerequisite(217));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_69_MQ060"));

		AddReward(new ItemReward("COLLECT_308", 1));
		AddReward(new ItemReward("misc_scrollskulp", 1));

		AddDialogHook("FLASH64_KARRIAT", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH64_KARRIAT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDERFORTRESS67_HQ1_start1", "UNDERFORTRESS67_HQ1", "Alright, I'll help you", "You should pay a reasonable price."))
		{
			case 1:
				await dialog.Msg("UNDERFORTRESS67_HQ1_agree1");
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

		await dialog.Msg("UNDERFORTRESS67_HQ1_succ1");
		// Func/UNDER67_HIDDENQ1_COMP_FUNC;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

