//--- Melia Script -----------------------------------------------------------
// Improvements
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Molly.
//---------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Characters.Components;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(60152)]
public class Quest60152Script : QuestScript
{
	protected override void Load()
	{
		SetId(60152);
		SetName("Improvements");
		SetDescription("Talk to Watcher Molly");

		AddPrerequisite(new LevelPrerequisite(32));

		AddObjective("kill0", "Kill 3 Leafly(s)", new KillObjective(3, MonsterId.Leafly));
		AddObjective("kill1", "Kill 4 Spion Archer(s)", new KillObjective(4, MonsterId.Spion_Bow));
		AddObjective("kill2", "Kill 2 Mali(s)", new KillObjective(2, MonsterId.Mally));

		AddReward(new ExpReward(2686, 2686));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 448));

		AddDialogHook("GELE572_NPC_MORI", "BeforeStart", BeforeStart);
		AddDialogHook("GELE572_NPC_MORI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE572_RP_1_1", "GELE572_RP_1", "I will try", "I'll find the other people"))
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

		var timedAction = await character.Components.Get<TimeActionComponent>().StartAsync("!@#$ItemCraftProcess#@!", "None", "TALK", TimeSpan.FromSeconds(1.2));

		if (timedAction == TimeActionResult.Completed)
		{
			character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
			await dialog.Msg("GELE572_RP_1_3");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

