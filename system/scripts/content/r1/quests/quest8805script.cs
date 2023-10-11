//--- Melia Script -----------------------------------------------------------
// Cleaned Up Workshop
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Robber Hubertas.
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

[QuestScript(8805)]
public class Quest8805Script : QuestScript
{
	protected override void Load()
	{
		SetId(8805);
		SetName("Cleaned Up Workshop");
		SetDescription("Talk to Grave Robber Hubertas");

		AddPrerequisite(new LevelPrerequisite(184));

		AddObjective("kill0", "Kill 14 Gray Jukopus(s) or Rambear(s) or Goblin Wizard(s)", new KillObjective(14, 400063, 47462, 57632));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5704));

		AddDialogHook("FLASH59_HUBERTAS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH59_HUBERTAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH59_SQ_06_01", "FLASH59_SQ_06", "Alright, I'll help you", "Decline"))
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

		await dialog.Msg("FLASH59_SQ_06_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

