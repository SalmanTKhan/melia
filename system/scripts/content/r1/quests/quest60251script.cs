//--- Melia Script -----------------------------------------------------------
// Going Below the Shadow (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Saya.
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

[QuestScript(60251)]
public class Quest60251Script : QuestScript
{
	protected override void Load()
	{
		SetId(60251);
		SetName("Going Below the Shadow (4)");
		SetDescription("Talk to Kupole Saya");

		AddPrerequisite(new LevelPrerequisite(338));
		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB482_MQ_3"));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("FLIBRARY482_SVAJA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY482_NERINGA_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FANTASYLIB482_MQ_4_1", "FANTASYLIB482_MQ_4", "Alright", "I'll wait a little bit"))
		{
			case 1:
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

		await dialog.Msg("FANTASYLIB482_MQ_4_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

