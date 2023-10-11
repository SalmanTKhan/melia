//--- Melia Script -----------------------------------------------------------
// Precious Life and Money
//--- Description -----------------------------------------------------------
// Quest to Talk with Chaser Zegaus.
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

[QuestScript(60110)]
public class Quest60110Script : QuestScript
{
	protected override void Load()
	{
		SetId(60110);
		SetName("Precious Life and Money");
		SetDescription("Talk with Chaser Zegaus");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAU11RE_MQ_05"));

		AddObjective("kill0", "Kill 13 Popolion(s) or Hanaming(s) or Red Kepa(s) or Woodin(s)", new KillObjective(13, 58009, 58007, 58088, 41294));

		AddReward(new ExpReward(2686, 2686));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 169));

		AddDialogHook("SIAULIAI11RE_JEGAUS", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI11RE_JEGAUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU11RE_SQ_07_01", "SIAU11RE_SQ_07", "I will protect you", "Decline"))
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

