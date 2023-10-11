//--- Melia Script -----------------------------------------------------------
// Marks of a legend(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Aquilas.
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

[QuestScript(50211)]
public class Quest50211Script : QuestScript
{
	protected override void Load()
	{
		SetId(50211);
		SetName("Marks of a legend(1)");
		SetDescription("Talk to Aquilas");

		AddPrerequisite(new LevelPrerequisite(313));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14398));

		AddDialogHook("BRACKEN433_SUBQ1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN433_SUBQ1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_3_SQ1_START1", "BRACKEN43_3_SQ1", "Ask him to tell you since you are willing to help", "Tell him to obtain them himself"))
		{
			case 1:
				await dialog.Msg("BRACKEN43_3_SQ1_AGREE1");
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

		await dialog.Msg("BRACKEN43_3_SQ1_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

