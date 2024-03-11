//--- Melia Script -----------------------------------------------------------
// The Past of the Spirits (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Old Manager.
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

[QuestScript(50073)]
public class Quest50073Script : QuestScript
{
	protected override void Load()
	{
		SetId(50073);
		SetName("The Past of the Spirits (2)");
		SetDescription("Talk to the Old Manager");

		AddPrerequisite(new LevelPrerequisite(211));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_68_MQ010"));

		AddObjective("collect0", "Collect 7 Demon Bones(s)", new CollectItemObjective("UNDER68_MQ2_ITEM01", 7));
		AddDrop("UNDER68_MQ2_ITEM01", 10f, "Deadbornscab_red");

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7385));

		AddDialogHook("EMINENT_68_1", "BeforeStart", BeforeStart);
		AddDialogHook("EMINENT_68_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDER68_MQ020_startnpc01", "UNDERFORTRESS_68_MQ020", "I will go get some demon bones", "Give me a second"))
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

		if (character.Inventory.HasItem("UNDER68_MQ2_ITEM01", 7))
		{
			character.Inventory.RemoveItem("UNDER68_MQ2_ITEM01", 7);
			await dialog.Msg("UNDER68_MQ020_succ01");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

