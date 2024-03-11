//--- Melia Script -----------------------------------------------------------
// A Chance of Recovery (3)
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

[QuestScript(8818)]
public class Quest8818Script : QuestScript
{
	protected override void Load()
	{
		SetId(8818);
		SetName("A Chance of Recovery (3)");
		SetDescription("Talk to Cryomancer Kostas");

		AddPrerequisite(new LevelPrerequisite(187));
		AddPrerequisite(new CompletedPrerequisite("FLASH60_SQ_05"));

		AddReward(new ExpReward(2379430, 2379430));
		AddReward(new ItemReward("expCard10", 2));
		AddReward(new ItemReward("Vis", 57970));

		AddDialogHook("FLASH60_KOSTAS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH60_KOSTAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH60_SQ_06_01", "FLASH60_SQ_06", "I will get the activating nucleus", "Pray for the successful research"))
		{
			case 1:
				await dialog.Msg("FLASH60_SQ_06_01_01");
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

		await dialog.Msg("FLASH60_SQ_07_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

