//--- Melia Script -----------------------------------------------------------
// A Vessel for a Spirit (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Bishop Aurelius.
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

[QuestScript(20300)]
public class Quest20300Script : QuestScript
{
	protected override void Load()
	{
		SetId(20300);
		SetName("A Vessel for a Spirit (1)");
		SetDescription("Talk to Bishop Aurelius");

		AddPrerequisite(new LevelPrerequisite(137));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));
		AddReward(new ItemReward("Vis", 3425));

		AddDialogHook("CHATHEDRAL53_MQ_BISHOP", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL53_MQ_BISHOP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL53_MQ01_select", "CHATHEDRAL53_MQ01", "Ask him how you can get guidance", "About the Great Cathedral", "I will find it alone"))
		{
			case 1:
				await dialog.Msg("CHATHEDRAL53_MQ01_startnpc01");
				dialog.UnHideNPC("CHATHEDRAL53_MQ01");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("CHATHEDRAL53_MQ01_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("CHATHEDRAL53_MQ01_succ01");
		dialog.HideNPC("CHATHEDRAL53_MQ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

