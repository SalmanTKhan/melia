//--- Melia Script -----------------------------------------------------------
// An Exhausted Body (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Experiment Victim Tilis.
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

[QuestScript(50123)]
public class Quest50123Script : QuestScript
{
	protected override void Load()
	{
		SetId(50123);
		SetName("An Exhausted Body (2)");
		SetDescription("Talk to Experiment Victim Tilis");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_1_SQ010"));

		AddObjective("kill0", "Kill 10 Green Apparition(s) or Red Velwriggler Mage(s)", new KillObjective(10, 103025, 57674));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 675));

		AddDialogHook("ABBEY641_PEAPLE01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY641_PEAPLE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_1_SQ020_startnpc01", "ABBAY_64_1_SQ020", "I will come back soon", "I can't help with that"))
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

