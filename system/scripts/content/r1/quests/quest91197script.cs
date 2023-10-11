//--- Melia Script -----------------------------------------------------------
// Laima's Call
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa at Orsha.
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

[QuestScript(91197)]
public class Quest91197Script : QuestScript
{
	protected override void Load()
	{
		SetId(91197);
		SetName("Laima's Call");
		SetDescription("Talk to Neringa at Orsha");

		AddPrerequisite(new LevelPrerequisite(490));
		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY_3_6"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("EP12_PRELUDE_NERINGA_ORSHA1", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_2_D_NICOPOLIS_1_MQ_1_HIDDEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_2_D_NICOPOLIS_1_MQ_1_DLG1", "EP15_2_D_NICOPOLIS_1_MQ_1", "I will go.", "I need more time to prepare."))
		{
			case 1:
				// Func/EP15_2_D_NICOPOLIS_1_MQ_1_warp_1;
				dialog.UnHideNPC("NPC_LITTLEGIRL_01");
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

		// Func/EP15_2_D_NICOPOLIS_1_MQ_1_track;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

