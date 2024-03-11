//--- Melia Script -----------------------------------------------------------
// Preventing the spread of poison
//--- Description -----------------------------------------------------------
// Quest to Talk to Researcher Veed.
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

[QuestScript(30217)]
public class Quest30217Script : QuestScript
{
	protected override void Load()
	{
		SetId(30217);
		SetName("Preventing the spread of poison");
		SetDescription("Talk to Researcher Veed");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_3_SQ_6"));

		AddObjective("kill0", "Kill 14 Green Rafflesia(s) or Red Cockat(s) or Big Red Griba(s) or Gray Winged Frog(s)", new KillObjective(14, 400502, 401643, 400464, 401463));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("ORCHARD_34_3_SQ_NPC_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_34_3_SQ_13_select", "ORCHARD_34_3_SQ_13", "Say that you will deal with the monsters", "Say that you think it'll be okay even if they are left alone"))
		{
			case 1:
				await dialog.Msg("ORCHARD_34_3_SQ_13_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

