//--- Melia Script -----------------------------------------------------------
// Marks of a legend(10)
//--- Description -----------------------------------------------------------
// Quest to Talk to Mechen.
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

[QuestScript(50220)]
public class Quest50220Script : QuestScript
{
	protected override void Load()
	{
		SetId(50220);
		SetName("Marks of a legend(10)");
		SetDescription("Talk to Mechen");

		AddPrerequisite(new LevelPrerequisite(313));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_3_SQ9"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14398));

		AddDialogHook("BRACKEN433_SUBQ2_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN433_ARROW_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_3_SQ10_START1", "BRACKEN43_3_SQ10", "Agree to help search around", "Wish them the best of luck"))
		{
			case 1:
				await dialog.Msg("BRACKEN43_3_SQ10_AGREE1");
				dialog.HideNPC("BRACKEN433_SUBQ5_NPC2");
				dialog.HideNPC("BRACKEN433_SUBQ1_NPC2");
				dialog.HideNPC("BRACKEN433_SUBQ3_NPC2");
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

		ZoneServer.Instance.World.FindNPC("BRACKEN433_ARROW_NPC")?.PlayEffectLocal(character.Connection, "F_buff_basic032_yellow_line", 1f, "BOT");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

