//--- Melia Script -----------------------------------------------------------
// Secure the safety
//--- Description -----------------------------------------------------------
// Quest to Talk with Villager Nella.
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

[QuestScript(80077)]
public class Quest80077Script : QuestScript
{
	protected override void Load()
	{
		SetId(80077);
		SetName("Secure the safety");
		SetDescription("Talk with Villager Nella");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_4_SQ_8"));

		AddObjective("kill0", "Kill 20 Blue Spion(s) or Blue Spion Archer(s) or Blue Spion Mage(s)", new KillObjective(20, 57910, 57912, 57913));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("SIAULIAI_35_1_VILLAGE_A", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_35_1_VILLAGE_A", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_35_1_SQ_13_start", "SIAULIAI_35_1_SQ_13", "Alright, I'll help you", "I'm busy now"))
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

		await dialog.Msg("SIAULIAI_35_1_SQ_13_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

