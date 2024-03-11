//--- Melia Script -----------------------------------------------------------
// Investigation Order
//--- Description -----------------------------------------------------------
// Quest to Talk to the General Ramin.
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

[QuestScript(91137)]
public class Quest91137Script : QuestScript
{
	protected override void Load()
	{
		SetId(91137);
		SetName("Investigation Order");
		SetDescription("Talk to the General Ramin");

		AddPrerequisite(new LevelPrerequisite(470));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE1_MQ_3"));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_1_Lamin1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_2_DCASTLE1_MQ_4_DLG1", "EP14_2_DCASTLE1_MQ_4", "Alright", "I need to do other things right now."))
		{
			case 1:
				await dialog.Msg("EP14_2_DCASTLE1_MQ_4_DLG2");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

