//--- Melia Script -----------------------------------------------------------
// Hoping the Goddess Will Recover
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Dreka.
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

[QuestScript(60185)]
public class Quest60185Script : QuestScript
{
	protected override void Load()
	{
		SetId(60185);
		SetName("Hoping the Goddess Will Recover");
		SetDescription("Talk to Believer Dreka");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_324_MQ_07"));

		AddReward(new ExpReward(49142, 49142));
		AddReward(new ItemReward("expCard6", 2));
		AddReward(new ItemReward("Vis", 2400));

		AddDialogHook("ORCHARD324_RP_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD324_RP_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD324_RP_1_1", "ORCHARD324_RP_1", "I will collect them", "Ignore"))
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

