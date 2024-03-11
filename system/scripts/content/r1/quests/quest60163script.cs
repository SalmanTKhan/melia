//--- Melia Script -----------------------------------------------------------
// Cure-all Medicine
//--- Description -----------------------------------------------------------
// Quest to Talk to Herbalist Talas.
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

[QuestScript(60163)]
public class Quest60163Script : QuestScript
{
	protected override void Load()
	{
		SetId(60163);
		SetName("Cure-all Medicine");
		SetDescription("Talk to Herbalist Talas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_3_SQ010"));

		AddReward(new ExpReward(16884, 16884));
		AddReward(new ItemReward("expCard3", 2));
		AddReward(new ItemReward("Vis", 504));

		AddDialogHook("BRACKEN633_PEAPLE01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN633_PEAPLE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN633_RP_1_1", "BRACKEN633_RP_1", "Alright, I'll help you", "I'm busy"))
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


		return HookResult.Break;
	}
}

