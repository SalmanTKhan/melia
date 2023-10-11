//--- Melia Script -----------------------------------------------------------
// Rescue Rose (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Edmundas in the Main Hall Atrium.
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

[QuestScript(50136)]
public class Quest50136Script : QuestScript
{
	protected override void Load()
	{
		SetId(50136);
		SetName("Rescue Rose (3)");
		SetDescription("Talk to Edmundas in the Main Hall Atrium");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_3_MQ020"));

		AddReward(new ExpReward(126630, 126630));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 954));

		AddDialogHook("ABBEY643_EDMONDA02", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY643_EDMONDA02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_3_MQ030_startnpc01", "ABBAY_64_3_MQ030", "I'll destroy the magic crystal", "Rose could be mentally affected; that's not right"))
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

