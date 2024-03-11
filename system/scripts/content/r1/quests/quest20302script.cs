//--- Melia Script -----------------------------------------------------------
// A Vessel for a Spirit (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Bishop Aurelius.
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

[QuestScript(20302)]
public class Quest20302Script : QuestScript
{
	protected override void Load()
	{
		SetId(20302);
		SetName("A Vessel for a Spirit (3)");
		SetDescription("Talk to Bishop Aurelius");

		AddPrerequisite(new LevelPrerequisite(137));
		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL53_MQ02"));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));
		AddReward(new ItemReward("Vis", 3425));

		AddDialogHook("CHATHEDRAL53_MQ_BISHOP", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL_BISHOP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL53_MQ03_select01", "CHATHEDRAL53_MQ03", "Ask him how to call him", "Decline"))
		{
			case 1:
				await dialog.Msg("CHATHEDRAL53_MQ03_startnpc01");
				dialog.HideNPC("CHATHEDRAL53_MQ_BISHOP");
				ZoneServer.Instance.World.FindNPC("CHATHEDRAL53_MQ_BISHOP")?.PlayEffectLocal(character.Connection, "F_buff_basic025_white_line_2", 1f, "BOT");
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

		await dialog.Msg("CHATHEDRAL53_MQ03_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

