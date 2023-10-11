//--- Melia Script -----------------------------------------------------------
// First Step Towards the Final Battle (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa's Illusion.
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

[QuestScript(80444)]
public class Quest80444Script : QuestScript
{
	protected override void Load()
	{
		SetId(80444);
		SetName("First Step Towards the Final Battle (3)");
		SetDescription("Talk to Neringa's Illusion");

		AddPrerequisite(new LevelPrerequisite(421));
		AddPrerequisite(new CompletedPrerequisite("D_CASTLE_19_1_MQ_02"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));
		AddReward(new ItemReward("Vis", 24418));

		AddDialogHook("D_CASTLE_19_1_MQ_NERINGA", "BeforeStart", BeforeStart);
		AddDialogHook("D_CASTLE_19_1_MQ_04_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("D_CASTLE_19_1_MQ_03_ST", "D_CASTLE_19_1_MQ_03", "Alright", "I need time to prepare."))
		{
			case 1:
				// Func/D_CASTLE_19_1_MQ_03_START_RUN;
				dialog.UnHideNPC("D_CASTLE_19_1_MQ_03_OBJ_1");
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

		// Func/D_CASTLE_19_1_MQ_03_SUCCESS_DLG_RUN;
		dialog.UnHideNPC("D_CASTLE_19_1_MQ_04_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

