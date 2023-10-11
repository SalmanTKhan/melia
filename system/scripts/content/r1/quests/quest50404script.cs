//--- Melia Script -----------------------------------------------------------
// Research Archives in Tyrimai Empty Lot
//--- Description -----------------------------------------------------------
// Quest to Investigate the Area Where Old Research Papers May Be Stored.
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

[QuestScript(50404)]
public class Quest50404Script : QuestScript
{
	protected override void Load()
	{
		SetId(50404);
		SetName("Research Archives in Tyrimai Empty Lot");
		SetDescription("Investigate the Area Where Old Research Papers May Be Stored");

		AddPrerequisite(new LevelPrerequisite(387));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_3_SQ_03"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("NICO813_SUBQ042_ITEM1", 1));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 28000));

		AddDialogHook("NICO813_SUBQ_SEAL3", "BeforeStart", BeforeStart);
		AddDialogHook("NICO813_SUBQ_SEAL3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


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

