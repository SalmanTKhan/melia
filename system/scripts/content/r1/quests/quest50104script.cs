//--- Melia Script -----------------------------------------------------------
// Frightened Herbalist
//--- Description -----------------------------------------------------------
// Quest to Talk to Herbalist Ash.
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

[QuestScript(50104)]
public class Quest50104Script : QuestScript
{
	protected override void Load()
	{
		SetId(50104);
		SetName("Frightened Herbalist");
		SetDescription("Talk to Herbalist Ash");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 10 Lapasape Mage(s)", new KillObjective(10, MonsterId.Lapasape_Mage));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 448));
		AddReward(new ItemReward("Drug_SP1_Q", 30));

		AddDialogHook("BRACKEN632_PEAPLE01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN632_PEAPLE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN_63_2_SQ010_startnpc01", "BRACKEN_63_2_SQ010", "I will tidy up the place", "There's too many demons; I can't do it"))
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

