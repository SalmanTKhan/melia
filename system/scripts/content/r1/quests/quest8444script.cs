//--- Melia Script -----------------------------------------------------------
// Call the Guardian
//--- Description -----------------------------------------------------------
// Quest to Read the Royal Mausoleum Archive.
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

[QuestScript(8444)]
public class Quest8444Script : QuestScript
{
	protected override void Load()
	{
		SetId(8444);
		SetName("Call the Guardian");
		SetDescription("Read the Royal Mausoleum Archive");

		AddPrerequisite(new LevelPrerequisite(92));

		AddObjective("kill0", "Kill 6 Venucelos(s)", new KillObjective(6, MonsterId.Dog_Of_King));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1840));

		AddDialogHook("ZACHA4F_SQ_03", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA4F_SQ_03", "ZACHA4F_SQ_03", "Let's defeat the hostile Venucelos", "I'll wait a little bit"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

