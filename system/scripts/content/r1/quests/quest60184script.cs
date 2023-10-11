//--- Melia Script -----------------------------------------------------------
// Violent Rampage
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Rovli.
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

[QuestScript(60184)]
public class Quest60184Script : QuestScript
{
	protected override void Load()
	{
		SetId(60184);
		SetName("Violent Rampage");
		SetDescription("Talk to Priest Rovli");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 9 Ferret Empty Porter(s) or Ferret Slinger(s) or Ferret Searcher(s)", new KillObjective(9, 57852, 57854, 57853));

		AddReward(new ExpReward(49142, 49142));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("Vis", 1840));

		AddDialogHook("ORCHARD323_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD323_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD323_RP_1_1", "ORCHARD323_RP_1", "Alright, I'll help you", "Decline"))
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


		return HookResult.Break;
	}
}

