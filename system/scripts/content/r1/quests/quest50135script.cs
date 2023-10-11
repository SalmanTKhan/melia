//--- Melia Script -----------------------------------------------------------
// Rescue Rose (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Edmundas.
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

[QuestScript(50135)]
public class Quest50135Script : QuestScript
{
	protected override void Load()
	{
		SetId(50135);
		SetName("Rescue Rose (2)");
		SetDescription("Talk to Edmundas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_3_MQ010"));

		AddObjective("collect0", "Collect 6 Brown Hummingbird Mucus(s)", new CollectItemObjective("ABBAY643_MQ1_ITEM01", 6));
		AddDrop("ABBAY643_MQ1_ITEM01", 7f, "humming_bud_purple");

		AddReward(new ExpReward(126630, 126630));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 954));

		AddDialogHook("ABBEY643_EDMONDA01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY643_EDMONDA01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_3_MQ020_startnpc01", "ABBAY_64_3_MQ020", "I'll collect some mucus for you", "We should consider there won't be any side effects to overloading the device"))
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

