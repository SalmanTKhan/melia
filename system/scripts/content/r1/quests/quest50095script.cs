//--- Melia Script -----------------------------------------------------------
// Nervous Vendor
//--- Description -----------------------------------------------------------
// Quest to Talk to Traveling Merchant Gomez.
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

[QuestScript(50095)]
public class Quest50095Script : QuestScript
{
	protected override void Load()
	{
		SetId(50095);
		SetName("Nervous Vendor");
		SetDescription("Talk to Traveling Merchant Gomez");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_1_MQ010"));

		AddObjective("kill0", "Kill 10 Parrot(s) or Polibu(s) or Leafnut(s) or Vubbe Chaser(s)", new KillObjective(10, 58018, 58019, 47488, 103023));

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 406));

		AddDialogHook("BRACKEN631_TRADESMAN03", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN631_TRADESMAN03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN_63_1_SQ020_startnpc01", "BRACKEN_63_1_SQ020", "I'll defeat the monsters around", "It's best to escape to somewhere safe"))
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

