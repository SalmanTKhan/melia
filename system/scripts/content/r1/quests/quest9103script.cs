//--- Melia Script -----------------------------------------------------------
// Owl Burial Ground Test
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Keeper Romas.
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

[QuestScript(9103)]
public class Quest9103Script : QuestScript
{
	protected override void Load()
	{
		SetId(9103);
		SetName("Owl Burial Ground Test");
		SetDescription("Talk to Grave Keeper Romas");

		AddPrerequisite(new LevelPrerequisite(109));

		AddObjective("kill0", "Kill 15 Ellomago(s) or Red Meduja(s) or Sakmoli(s) or Ridimed(s)", new KillObjective(15, 41443, 400244, 400561, 400541));

		AddReward(new ItemReward("QUEST_HAIRCOLOR_01", 1));

		AddDialogHook("KATYN_7_2_HQ01_NPC02", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_7_2_HQ01_NPC02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_7_2_HQ_01_select01", "KATYN_7_2_HQ_01", "I'm not weak", "Decline"))
		{
			case 1:
				await dialog.Msg("KATYN_7_2_HQ_01_startnpc01");
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

		await dialog.Msg("KATYN_7_2_HQ_01_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

