//--- Melia Script -----------------------------------------------------------
// Welcomed One (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Assistant Commander Talon.
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

[QuestScript(50147)]
public class Quest50147Script : QuestScript
{
	protected override void Load()
	{
		SetId(50147);
		SetName("Welcomed One (2)");
		SetDescription("Talk to Assistant Commander Talon");

		AddPrerequisite(new LevelPrerequisite(238));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_70_SQ1"));

		AddReward(new ItemReward("squire_food_03", 5));
		AddReward(new ItemReward("squire_food_01", 5));

		AddDialogHook("TABLE70_CAPTIN1_1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE70_SOLDIER2_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_70_SQ2_startnpc01", "TABLELAND_70_SQ2", "Can I take some food?", "You don't have to worry about that."))
		{
			case 1:
				await dialog.Msg("TABLELAND_70_SQ2_startnpc02");
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

		await dialog.Msg("TABLELAND_70_SQ2_succ01");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Received the food.");
		await dialog.Msg("TABLELAND_70_SQ2_succ02");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

