//--- Melia Script -----------------------------------------------------------
// Habitat
//--- Description -----------------------------------------------------------
// Quest to Talk to Lumberjack Luoval.
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

[QuestScript(60182)]
public class Quest60182Script : QuestScript
{
	protected override void Load()
	{
		SetId(60182);
		SetName("Habitat");
		SetDescription("Talk to Lumberjack Luoval");

		AddPrerequisite(new LevelPrerequisite(103));

		AddObjective("kill0", "Kill 11 Winged Frog(s) or Gravegolem(s) or Old Hook(s) or Zolem(s)", new KillObjective(11, 401461, 401601, 401741, 41287));

		AddReward(new ExpReward(49142, 49142));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("Vis", 2472));

		AddDialogHook("REMAINS39_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS39_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS39_RP_1_1", "REMAINS39_RP_1", "Alright, I'll help you", "Disregard"))
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

		await dialog.Msg("REMAINS39_RP_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

