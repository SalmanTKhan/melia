//--- Melia Script -----------------------------------------------------------
// A New Attack (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Schaffenstar Adjutant Apollonius.
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

[QuestScript(72217)]
public class Quest72217Script : QuestScript
{
	protected override void Load()
	{
		SetId(72217);
		SetName("A New Attack (2)");
		SetDescription("Talk to Schaffenstar Adjutant Apollonius");

		AddPrerequisite(new LevelPrerequisite(392));
		AddPrerequisite(new CompletedPrerequisite("CASTLE93_MAIN01"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE93_NPC_MAIN01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE93_NPC_MAIN01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE93_MAIN02_01", "CASTLE93_MAIN02", "Alright, I'll help you", "What happened here in the past?", "I can't really help you, sorry."))
		{
			case 1:
				await dialog.Msg("CASTLE93_MAIN02_02");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("CASTLE93_MAIN02_01_EX");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("CASTLE93_MAIN02_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

