//--- Melia Script -----------------------------------------------------------
// Ardor for Study (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Archaeologist Friedka.
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

[QuestScript(20144)]
public class Quest20144Script : QuestScript
{
	protected override void Load()
	{
		SetId(20144);
		SetName("Ardor for Study (1)");
		SetDescription("Talk to Archaeologist Friedka");

		AddPrerequisite(new LevelPrerequisite(69));

		AddObjective("collect0", "Collect 5 Hogma Amulet(s)", new CollectItemObjective("ROKAS28_MQ3_ITEM", 5));
		AddDrop("ROKAS28_MQ3_ITEM", 4f, "hogma_archer");

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1311));

		AddDialogHook("ROKAS28_FRIDKA", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS28_MQ3_select", "ROKAS28_MQ3", "I'll help", "Decline"))
		{
			case 1:
				await dialog.Msg("ROKAS28_MQ3_select_Q");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS28_ENTICE");
	}
}

