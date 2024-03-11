//--- Melia Script -----------------------------------------------------------
// Founder of the Green Family
//--- Description -----------------------------------------------------------
// Quest to Talk to the Druid Master.
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

[QuestScript(90177)]
public class Quest90177Script : QuestScript
{
	protected override void Load()
	{
		SetId(90177);
		SetName("Founder of the Green Family");
		SetDescription("Talk to the Druid Master");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("LOWLV_MASTER_ENCY_SQ_20"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("misc_ore17", 1));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("JOB_DRUID3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_DRUID3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LOWLV_GREEN_SQ_10_ST", "LOWLV_GREEN_SQ_10", "I'll help you find what you're looking for.", "That seems difficult"))
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


		return HookResult.Break;
	}
}

