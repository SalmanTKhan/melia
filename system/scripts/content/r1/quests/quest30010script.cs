//--- Melia Script -----------------------------------------------------------
// The Spatial Magic Gem of Promise (1)
//--- Description -----------------------------------------------------------
// Quest to Examine the Magic Gem Fusion Device.
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

[QuestScript(30010)]
public class Quest30010Script : QuestScript
{
	protected override void Load()
	{
		SetId(30010);
		SetName("The Spatial Magic Gem of Promise (1)");
		SetDescription("Examine the Magic Gem Fusion Device");

		AddPrerequisite(new LevelPrerequisite(191));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_38_2_SQ_06"));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 5921));

		AddDialogHook("CATACOMB_04_OBJ_01", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_04_OBJ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_04_SQ_03_01", "CATACOMB_04_SQ_03"))
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
		character.Quests.Start("CATACOMB_04_SQ_04");
	}
}

