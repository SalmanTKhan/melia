//--- Melia Script -----------------------------------------------------------
// You Can't Drink That
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Modis.
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

[QuestScript(90016)]
public class Quest90016Script : QuestScript
{
	protected override void Load()
	{
		SetId(90016);
		SetName("You Can't Drink That");
		SetDescription("Talk to Hunter Modis");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_84_MQ_06"));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1292));

		AddDialogHook("3CMLAKE_84_HUNTER", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_84_HUNTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE_84_SQ_01_DLG_01", "F_3CMLAKE_84_SQ_01", "I'll get it. ", "I don't think I have time for that"))
		{
			case 1:
				await dialog.Msg("3CMLAKE_84_SQ_01_AG");
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

