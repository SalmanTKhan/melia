//--- Melia Script -----------------------------------------------------------
// Different Circumstances (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Barbarian Wolke.
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

[QuestScript(60414)]
public class Quest60414Script : QuestScript
{
	protected override void Load()
	{
		SetId(60414);
		SetName("Different Circumstances (4)");
		SetDescription("Talk to Barbarian Wolke");

		AddPrerequisite(new LevelPrerequisite(401));
		AddPrerequisite(new CompletedPrerequisite("CASTLE96_MQ_3"));

		AddObjective("kill0", "Kill 12 Gigglecat(s) or Ghoscat(s) or Arch Gargoyle(s)", new KillObjective(12, 59236, 59244, 59248));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 22857));

		AddDialogHook("CASTLE96_MQ_WOLKE_NPC", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE96_MQ_4_1", "CASTLE96_MQ_4", "Okay, I get it.", "Calm down"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

