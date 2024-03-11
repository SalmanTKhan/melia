//--- Melia Script -----------------------------------------------------------
// Find the Trace (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Kupole Leda.
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

[QuestScript(90134)]
public class Quest90134Script : QuestScript
{
	protected override void Load()
	{
		SetId(90134);
		SetName("Find the Trace (1)");
		SetDescription("Talk with Kupole Leda");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_5_SQ_40"));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("DCAPITAL_20_5_REDA", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_DCAPITAL_20_5_SQ_60_ST", "F_DCAPITAL_20_5_SQ_60", "Show me the way.", "Prithee, make haste and find it."))
		{
			case 1:
				await dialog.Msg("F_DCAPITAL_20_5_SQ_60_AG");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

