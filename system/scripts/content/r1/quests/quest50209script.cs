//--- Melia Script -----------------------------------------------------------
// Danger the Lurks in the Forest (8)
//--- Description -----------------------------------------------------------
// Quest to Talk with Oscaras.
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

[QuestScript(50209)]
public class Quest50209Script : QuestScript
{
	protected override void Load()
	{
		SetId(50209);
		SetName("Danger the Lurks in the Forest (8)");
		SetDescription("Talk with Oscaras");

		AddPrerequisite(new LevelPrerequisite(310));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_2_SQ7"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14260));
		AddReward(new ItemReward("BRACKEN432_SUBQ9_ITEM1", 1));

		AddDialogHook("BRACKEN432_SUBQ_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN432_SUBQ8_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_2_SQ8_START1", "BRACKEN43_2_SQ8", "How do you make the cure?", "Well, you are on your own."))
		{
			case 1:
				await dialog.Msg("BRACKEN43_2_SQ8_AGREE1");
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


		return HookResult.Break;
	}
}

