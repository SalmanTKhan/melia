//--- Melia Script -----------------------------------------------------------
// Preliminary Investigation (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Agent Notres.
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

[QuestScript(60107)]
public class Quest60107Script : QuestScript
{
	protected override void Load()
	{
		SetId(60107);
		SetName("Preliminary Investigation (1)");
		SetDescription("Talk with Agent Notres");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 9 Popolion(s) or Hanaming(s) or Red Kepa(s) or Woodin(s)", new KillObjective(9, 58009, 58007, 58088, 41294));

		AddReward(new ExpReward(2686, 2686));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 169));

		AddDialogHook("SIAULIAI11RE_NOTORESU", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU11RE_SQ_03_01", "SIAU11RE_SQ_03", "I'll try and check it out", "Go look for a safer place"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

