//--- Melia Script -----------------------------------------------------------
// True Nature of the Research (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Gatre.
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

[QuestScript(30134)]
public class Quest30134Script : QuestScript
{
	protected override void Load()
	{
		SetId(30134);
		SetName("True Nature of the Research (2)");
		SetDescription("Talk with Gatre");

		AddPrerequisite(new LevelPrerequisite(220));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_1_SQ_4"));

		AddObjective("collect0", "Collect 1 Lost Research Note, Chapter 1", new CollectItemObjective("ORCHARD_34_1_SQ_5_ITEM_1", 1));
		AddObjective("collect1", "Collect 1 Lost Research Note, Chapter 2", new CollectItemObjective("ORCHARD_34_1_SQ_5_ITEM_2", 1));
		AddDrop("ORCHARD_34_1_SQ_5_ITEM_1", 7f, 57453, 58028, 401445);
		AddDrop("ORCHARD_34_1_SQ_5_ITEM_2", 2f, 57453, 58028, 401445);

		AddReward(new ExpReward(3246138, 3246138));
		AddReward(new ItemReward("expCard11", 2));
		AddReward(new ItemReward("Vis", 7920));

		AddDialogHook("ORCHARD_34_1_SQ_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_34_1_SQ_5_select", "ORCHARD_34_1_SQ_5", "Ask what it is", "We should look for another way"))
		{
			case 1:
				await dialog.Msg("ORCHARD_34_1_SQ_5_agree");
				dialog.UnHideNPC("ORCHARD_34_1_SQ_2_OBJ_3");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

