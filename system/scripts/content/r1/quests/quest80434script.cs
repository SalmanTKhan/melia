//--- Melia Script -----------------------------------------------------------
// Swore to Protect (8)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Medeina.
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

[QuestScript(80434)]
public class Quest80434Script : QuestScript
{
	protected override void Load()
	{
		SetId(80434);
		SetName("Swore to Protect (8)");
		SetDescription("Talk to Goddess Medeina");

		AddPrerequisite(new LevelPrerequisite(415));
		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_2_MQ_07"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23655));

		AddDialogHook("F_MAPLE_242_MQ_MEDEINA_NPC1_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_242_MQ_MEDEINA_NPC1_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_MAPLE_24_2_MQ_08_ST", "F_MAPLE_24_2_MQ_08", "Okay, I'll be right back.", "I dunno where to go."))
		{
			case 1:
				await dialog.Msg("F_MAPLE_24_2_MQ_08_AFST");
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

		await dialog.Msg("F_MAPLE_24_2_MQ_08_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

