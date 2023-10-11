//--- Melia Script -----------------------------------------------------------
// Marks of a legend(4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Woognis.
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

[QuestScript(50214)]
public class Quest50214Script : QuestScript
{
	protected override void Load()
	{
		SetId(50214);
		SetName("Marks of a legend(4)");
		SetDescription("Talk to Woognis");

		AddPrerequisite(new LevelPrerequisite(313));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_3_SQ3"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 14398));

		AddDialogHook("BRACKEN433_SUBQ3_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN433_SUBQ3_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_3_SQ4_START1", "BRACKEN43_3_SQ4", "Agree to search together", "Say that he is on his own"))
		{
			case 1:
				await dialog.Msg("BRACKEN43_3_SQ4_AGREE1");
				// Func/BRACKEN433_SUBQ4_AGREE_FUNC;
				dialog.HideNPC("BRACKEN433_SUBQ3_NPC1");
				await dialog.Msg("FadeOutIN/1000");
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

		await dialog.Msg("BRACKEN43_3_SQ4_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

