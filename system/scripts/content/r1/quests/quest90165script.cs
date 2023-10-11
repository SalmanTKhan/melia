//--- Melia Script -----------------------------------------------------------
// Encyclopedia of Masters, Chapter 2
//--- Description -----------------------------------------------------------
// Quest to Talk with the Sage Master.
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

[QuestScript(90165)]
public class Quest90165Script : QuestScript
{
	protected override void Load()
	{
		SetId(90165);
		SetName("Encyclopedia of Masters, Chapter 2");
		SetDescription("Talk with the Sage Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("Vis", 12180));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("misc_ore17", 2));

		AddDialogHook("SAGE_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("SAGE_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LOWLV_MASTER_ENCY_SQ_10_ST", "LOWLV_MASTER_ENCY_SQ_10", "I am happy to help.", "I am not particularly interested."))
		{
			case 1:
				await dialog.Msg("LOWLV_MASTER_ENCY_SQ_10_AG");
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

