//--- Melia Script -----------------------------------------------------------
// Uncomfortable Alliance
//--- Description -----------------------------------------------------------
// Quest to Talk to Adjutant General Hans.
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

[QuestScript(8833)]
public class Quest8833Script : QuestScript
{
	protected override void Load()
	{
		SetId(8833);
		SetName("Uncomfortable Alliance");
		SetDescription("Talk to Adjutant General Hans");

		AddPrerequisite(new LevelPrerequisite(193));

		AddObjective("kill0", "Kill 5 Lemur(s) or Goblin Charger(s) or Goblin Magician(s)", new KillObjective(5, 47306, 57636, 57634));

		AddReward(new ExpReward(1189715, 1189715));
		AddReward(new ItemReward("expCard10", 1));
		AddReward(new ItemReward("Vis", 5983));

		AddDialogHook("FLASH63_HANS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH63_HANS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH63_SQ_01_01", "FLASH63_SQ_01", "Tell him that you would accept the suggestion", "About the dangerous deal", "Decline"))
		{
			case 1:
				await dialog.Msg("FLASH63_SQ_01_01_01");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH63_SQ_01_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH63_SQ_01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

