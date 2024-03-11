//--- Melia Script -----------------------------------------------------------
// Research Archives in Magija Slove (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Wizard Nidia.
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

[QuestScript(50406)]
public class Quest50406Script : QuestScript
{
	protected override void Load()
	{
		SetId(50406);
		SetName("Research Archives in Magija Slove (2)");
		SetDescription("Talk to Wizard Nidia");

		AddPrerequisite(new LevelPrerequisite(387));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_3_SQ_04_3"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("NICO813_SUBQ044_ITEM1", 1));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 29000));

		AddDialogHook("NICO813_SUBQ_NPC2_2", "BeforeStart", BeforeStart);
		AddDialogHook("NICO813_SUBQ_SEAL4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICO813_SUBQ044_START1", "F_NICOPOLIS_81_3_SQ_04_4", "What is it?", "Leave this place"))
		{
			case 1:
				await dialog.Msg("NICO813_SUBQ044_AGREE1");
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You've replaced the Old Research Papers with the Forged Research Papers.");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

