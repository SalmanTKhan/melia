//--- Melia Script -----------------------------------------------------------
// The Spatial Magic Gem of Sacrifice (1)
//--- Description -----------------------------------------------------------
// Quest to Examine the Magic Gem Fusion Device.
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

[QuestScript(30012)]
public class Quest30012Script : QuestScript
{
	protected override void Load()
	{
		SetId(30012);
		SetName("The Spatial Magic Gem of Sacrifice (1)");
		SetDescription("Examine the Magic Gem Fusion Device");

		AddPrerequisite(new LevelPrerequisite(191));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_38_2_SQ_06"));

		AddReward(new ExpReward(237943, 237943));
		AddReward(new ItemReward("expCard10", 3));
		AddReward(new ItemReward("Vis", 5921));

		AddDialogHook("CATACOMB_04_OBJ_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_04_SQ_05_01", "CATACOMB_04_SQ_05"))
		{
		}

		return HookResult.Break;
	}
}

