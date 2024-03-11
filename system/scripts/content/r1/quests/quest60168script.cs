//--- Melia Script -----------------------------------------------------------
// Monsters From the Settlement Clearing
//--- Description -----------------------------------------------------------
// Quest to Talk to Settler Rodonas.
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

[QuestScript(60168)]
public class Quest60168Script : QuestScript
{
	protected override void Load()
	{
		SetId(60168);
		SetName("Monsters From the Settlement Clearing");
		SetDescription("Talk to Settler Rodonas");

		AddPrerequisite(new LevelPrerequisite(69));

		AddObjective("kill0", "Kill 16 Pink Chupaluka(s) or Orange Sakmoli(s) or Black Ridimed(s) or Lepusbunny Assassin(s)", new KillObjective(16, 57353, 400563, 400543, 57601));

		AddReward(new ExpReward(24571, 24571));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Vis", 1311));

		AddDialogHook("SIAU501_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAU501_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU501_RP_1_1", "SIAU501_RP_1", "Alright, I'll help you", "I'm busy"))
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

		await dialog.Msg("SIAU501_RP_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

