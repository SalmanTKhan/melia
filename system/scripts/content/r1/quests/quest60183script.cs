//--- Melia Script -----------------------------------------------------------
// Thinking Ahead
//--- Description -----------------------------------------------------------
// Quest to Talk to Stonemason Canolyn.
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

[QuestScript(60183)]
public class Quest60183Script : QuestScript
{
	protected override void Load()
	{
		SetId(60183);
		SetName("Thinking Ahead");
		SetDescription("Talk to Stonemason Canolyn");

		AddPrerequisite(new LevelPrerequisite(107));
		AddPrerequisite(new CompletedPrerequisite("REMAINS40_SQ_02"));

		AddObjective("kill0", "Kill 13 Hallowventer(s) or Cockatrice(s) or Cockat(s)", new KillObjective(13, 41281, 401261, 401641));

		AddReward(new ExpReward(49142, 49142));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("REMAINS_40_CANOLIN_01", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS_40_CANOLIN_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAINS40_RP_1_1", "REMAINS40_RP_1", "Alright, I'll help you", "Not really my problem"))
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

		await dialog.Msg("REMAINS40_RP_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

