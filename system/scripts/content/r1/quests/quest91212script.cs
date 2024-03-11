//--- Melia Script -----------------------------------------------------------
// To the Sanctuary of Truth
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Laima.
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

[QuestScript(91212)]
public class Quest91212Script : QuestScript
{
	protected override void Load()
	{
		SetId(91212);
		SetName("To the Sanctuary of Truth");
		SetDescription("Talk to Goddess Laima");

		AddPrerequisite(new LevelPrerequisite(500));
		AddPrerequisite(new CompletedPrerequisite("EP16_1_NICOPOLIS_81_1_MQ1"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("NPC_LITTLEGIRL_01", "BeforeStart", BeforeStart);
		AddDialogHook("NPC_LITTLEGIRL_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP16_1_CATHEDRAL_MEDIUM_MQ2_NPC_DLG_1", "EP16_1_CATHEDRAL_MQ2", "Tell me the truth", "I'll come prepared to listen."))
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

		await dialog.Msg("EP16_1_CATHEDRAL_MEDIUM_MQ2_NPC_DLG_4");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

