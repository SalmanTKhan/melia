//--- Melia Script -----------------------------------------------------------
// Great Escape Portal (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Chronomancer Sabina.
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

[QuestScript(8830)]
public class Quest8830Script : QuestScript
{
	protected override void Load()
	{
		SetId(8830);
		SetName("Great Escape Portal (1)");
		SetDescription("Talk to Chronomancer Sabina");

		AddPrerequisite(new LevelPrerequisite(190));
		AddPrerequisite(new CompletedPrerequisite("FLASH61_SQ_07"));

		AddReward(new ExpReward(2379430, 2379430));
		AddReward(new ItemReward("expCard10", 2));
		AddReward(new ItemReward("Vis", 5890));

		AddDialogHook("FLASH61_SABINA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH61_SABINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH61_SQ_09_01", "FLASH61_SQ_09", "I'll participate", "About the danger that Sabina is talking about", "Tell him that you won't do anything dangerous"))
		{
			case 1:
				await dialog.Msg("FLASH61_SQ_09_01_01");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH61_SQ_09_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH61_SQ_09_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

