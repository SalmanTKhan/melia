//--- Melia Script -----------------------------------------------------------
// Antidote 
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hunter Master.
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

[QuestScript(50014)]
public class Quest50014Script : QuestScript
{
	protected override void Load()
	{
		SetId(50014);
		SetName("Antidote ");
		SetDescription("Talk to the Hunter Master");

		AddPrerequisite(new LevelPrerequisite(69));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_50_1_SQ_060"));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1311));

		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_50_1_SQ_GYTIS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_50_1_SQ_070_select01", "SIAULIAI_50_1_SQ_070", "Ask about the antidote", "I'll be back after a while"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_50_1_SQ_070_starnpc02");
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

		if (character.Inventory.HasItem("SIAULIAI50_DRUG01", 1))
		{
			character.Inventory.RemoveItem("SIAULIAI50_DRUG01", 1);
			await dialog.Msg("SIAULIAI_50_1_SQ_070_succ01");
			await dialog.Msg("FadeOutIN/1000");
			await dialog.Msg("NPCAin/SIAULIAI_50_1_SQ_MAN02/std/1");
			await dialog.Msg("NPCChat/SIAULIAI_50_1_SQ_MAN03/아픈게 좀 나아진거 같아.");
			await dialog.Msg("SIAULIAI_50_1_SQ_070_succ02");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

