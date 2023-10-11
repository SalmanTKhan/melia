//--- Melia Script -----------------------------------------------------------
// Reclaim the Camp (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Royal Army Guard Delus.
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

[QuestScript(50059)]
public class Quest50059Script : QuestScript
{
	protected override void Load()
	{
		SetId(50059);
		SetName("Reclaim the Camp (4)");
		SetDescription("Talk to Royal Army Guard Delus");

		AddPrerequisite(new LevelPrerequisite(204));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_66_MQ040"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7140));

		AddDialogHook("UNDER66_DELLOOS03", "BeforeStart", BeforeStart);
		AddDialogHook("UNDER66_DELLOOS03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDERFORTRESS_66_MQ050_startnpc01", "UNDERFORTRESS_66_MQ050", "Alright, I'll help you", "I will leave now"))
		{
			case 1:
				await dialog.Msg("UNDERFORTRESS_66_MQ050_startnpc02");
				// Func/UNDER66_MQ5_NPCUNHIDE;
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

		await dialog.Msg("UNDERFORTRESS_66_MQ050_succ01");
		// Func/UNDER66_MQ6_ITEM01_TAKE;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

