//--- Melia Script -----------------------------------------------------------
// Suspicious Sanctum (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Keeper Sigis.
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

[QuestScript(80016)]
public class Quest80016Script : QuestScript
{
	protected override void Load()
	{
		SetId(80016);
		SetName("Suspicious Sanctum (2)");
		SetDescription("Talk to Grave Keeper Sigis");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_1_SQ_05"));

		AddObjective("collect0", "Collect 6 Evil Magic Trace(s)", new CollectItemObjective("CATACOMB_33_1_SQ_09_ITEM", 6));
		AddDrop("CATACOMB_33_1_SQ_09_ITEM", 6f, "Fisherman_green");

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1330));

		AddDialogHook("CATACOMB_33_1_SIGIS", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_33_1_SIGIS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_33_1_SQ_09_start", "CATACOMB_33_1_SQ_09", "I'll get it", "Do as you wish now"))
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

