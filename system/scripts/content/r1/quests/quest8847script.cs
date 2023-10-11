//--- Melia Script -----------------------------------------------------------
// Irrevocable Accident (1)
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

[QuestScript(8847)]
public class Quest8847Script : QuestScript
{
	protected override void Load()
	{
		SetId(8847);
		SetName("Irrevocable Accident (1)");
		SetDescription("Talk to Wilhelmina Carriot");

		AddPrerequisite(new LevelPrerequisite(196));

		AddReward(new ExpReward(237943, 237943));
		AddReward(new ItemReward("expCard10", 3));
		AddReward(new ItemReward("Vis", 6076));

		AddDialogHook("FLASH64_KARRIAT", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH64_SQ_03_01", "FLASH64_SQ_03", "I'll go there", "Decline"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

