//--- Melia Script -----------------------------------------------------------
// A Chance of Recovery (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Cryomancer Kostas.
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

[QuestScript(8817)]
public class Quest8817Script : QuestScript
{
	protected override void Load()
	{
		SetId(8817);
		SetName("A Chance of Recovery (2)");
		SetDescription("Talk to Cryomancer Kostas");

		AddPrerequisite(new LevelPrerequisite(187));
		AddPrerequisite(new CompletedPrerequisite("FLASH60_SQ_04"));

		AddReward(new ExpReward(2379430, 2379430));
		AddReward(new ItemReward("expCard10", 2));
		AddReward(new ItemReward("Vis", 5797));

		AddDialogHook("FLASH60_KOSTAS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH60_KOSTAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH60_SQ_05_01", "FLASH60_SQ_05", "I will experiment it", "About the research of the petrification", "Tell him that you can't help anymore"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH60_SQ_05_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH60_SQ_05_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

