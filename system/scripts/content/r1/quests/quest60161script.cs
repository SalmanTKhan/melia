//--- Melia Script -----------------------------------------------------------
// Try Your Best
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Bronius.
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

[QuestScript(60161)]
public class Quest60161Script : QuestScript
{
	protected override void Load()
	{
		SetId(60161);
		SetName("Try Your Best");
		SetDescription("Talk to Believer Bronius");

		AddPrerequisite(new LevelPrerequisite(64));
		AddPrerequisite(new CompletedPrerequisite("THORN21_MQ01"));

		AddReward(new ExpReward(8442, 8442));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("THORN21_BELIEVER", "BeforeStart", BeforeStart);
		AddDialogHook("THORN21_BELIEVER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN21_RP_2_1", "THORN21_RP_2", "I'll purify it", "Let's wait for a while."))
		{
			case 1:
				dialog.UnHideNPC("THORN21_RP_2_OBJ");
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

		await dialog.Msg("THORN21_RP_2_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

