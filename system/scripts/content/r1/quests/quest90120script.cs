//--- Melia Script -----------------------------------------------------------
// Green Autumn Leaves
//--- Description -----------------------------------------------------------
// Quest to Talk to Refugee Representative Morkus.
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

[QuestScript(90120)]
public class Quest90120Script : QuestScript
{
	protected override void Load()
	{
		SetId(90120);
		SetName("Green Autumn Leaves");
		SetDescription("Talk to Refugee Representative Morkus");

		AddPrerequisite(new LevelPrerequisite(285));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_2_SQ_10"));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 11970));

		AddDialogHook("MAPLE_25_2_MORKUS", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_2_MORKUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_2_SQ_20_ST", "MAPLE_25_2_SQ_20", "I'll do it", "Tell him that it would be hard"))
		{
			case 1:
				await dialog.Msg("MAPLE_25_2_SQ_20_AG");
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

		await dialog.Msg("MAPLE_25_2_SQ_20_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

