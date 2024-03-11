//--- Melia Script -----------------------------------------------------------
// Rose's Friends (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Traveling Merchant Rose.
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

[QuestScript(50092)]
public class Quest50092Script : QuestScript
{
	protected override void Load()
	{
		SetId(50092);
		SetName("Rose's Friends (2)");
		SetDescription("Talk to Traveling Merchant Rose");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_1_MQ020"));

		AddReward(new ExpReward(40290, 40290));
		AddReward(new ItemReward("expCard2", 3));
		AddReward(new ItemReward("Vis", 406));

		AddDialogHook("BRACKEN631_ROZE", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN631_TRADESMAN05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN_63_1_MQ030_startnpc01", "BRACKEN_63_1_MQ030", "I will go find the merchants with Laswi", "I need some time to prepare"))
		{
			case 1:
				dialog.HideNPC("BRACKEN631_DOG");
				// Func/BRACKEN631_MQ3_DOG_AI_CREATE;
				await dialog.Msg("FadeOutIN/1000");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Have Laswi follow the scent of each merchant and find them");
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

