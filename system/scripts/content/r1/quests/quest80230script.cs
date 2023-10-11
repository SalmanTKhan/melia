//--- Melia Script -----------------------------------------------------------
// Road to the Ruthless Dungeon
//--- Description -----------------------------------------------------------
// Quest to Find Sentinel Rian.
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

[QuestScript(80230)]
public class Quest80230Script : QuestScript
{
	protected override void Load()
	{
		SetId(80230);
		SetName("Road to the Ruthless Dungeon");
		SetDescription("Find Sentinel Rian");

		AddPrerequisite(new LevelPrerequisite(80));

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 900));

		AddDialogHook("INSTANCE_DUNGEON", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("TUTO_INSTANT_DUNGEON_succ01");
		dialog.ShowHelp("TUTO_INSTANT_DUNGEON");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

