//--- Melia Script -----------------------------------------------------------
// Glorious Road
//--- Description -----------------------------------------------------------
// Quest to Talk to Royal Army Guard Retia.
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

[QuestScript(8801)]
public class Quest8801Script : QuestScript
{
	protected override void Load()
	{
		SetId(8801);
		SetName("Glorious Road");
		SetDescription("Talk to Royal Army Guard Retia");

		AddPrerequisite(new LevelPrerequisite(184));

		AddObjective("kill0", "Kill 5 Gray Jukopus(s) or Rambear(s) or Goblin Wizard(s)", new KillObjective(5, 400063, 47462, 57632));

		AddReward(new ExpReward(1046670, 1046670));
		AddReward(new ItemReward("expCard9", 1));
		AddReward(new ItemReward("Vis", 5704));

		AddDialogHook("FLASH59_RETIA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH59_RETIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH59_SQ_02_01", "FLASH59_SQ_02", "I'll help you", "About this city", "Decline"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH59_SQ_02_01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH59_SQ_02_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

