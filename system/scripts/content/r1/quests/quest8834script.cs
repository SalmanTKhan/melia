//--- Melia Script -----------------------------------------------------------
// All the Same (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Adjutant General Hans.
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

[QuestScript(8834)]
public class Quest8834Script : QuestScript
{
	protected override void Load()
	{
		SetId(8834);
		SetName("All the Same (1)");
		SetDescription("Talk to Adjutant General Hans");

		AddPrerequisite(new LevelPrerequisite(193));

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

		switch (await dialog.Select("FLASH63_SQ_02_01", "FLASH63_SQ_02", "Alright, I'll help you", "Tell him that you don't want to do something dangerous"))
		{
			case 1:
				await dialog.Msg("FLASH63_SQ_02_01_01");
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

		await dialog.Msg("FLASH63_SQ_02_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

