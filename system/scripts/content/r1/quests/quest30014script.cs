//--- Melia Script -----------------------------------------------------------
// Completed Spatial Magic Gem
//--- Description -----------------------------------------------------------
// Quest to Activate the Magic Gem Fusion Device.
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

[QuestScript(30014)]
public class Quest30014Script : QuestScript
{
	protected override void Load()
	{
		SetId(30014);
		SetName("Completed Spatial Magic Gem");
		SetDescription("Activate the Magic Gem Fusion Device");

		AddPrerequisite(new LevelPrerequisite(191));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_04_SQ_02"), new CompletedPrerequisite("CATACOMB_04_SQ_04"), new CompletedPrerequisite("CATACOMB_04_SQ_06"));

		AddReward(new ExpReward(237943, 237943));
		AddReward(new ItemReward("expCard10", 3));
		AddReward(new ItemReward("Vis", 5921));

		AddDialogHook("CATACOMB_04_OBJ_01", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_04_OBJ_06", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_04_SQ_07_01", "CATACOMB_04_SQ_07"))
		{
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_04_SQ_08");
	}
}

