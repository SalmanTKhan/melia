//--- Melia Script -----------------------------------------------------------
// Recurrence Prevention (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Lanaldas.
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

[QuestScript(90018)]
public class Quest90018Script : QuestScript
{
	protected override void Load()
	{
		SetId(90018);
		SetName("Recurrence Prevention (2)");
		SetDescription("Talk to Lanaldas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_84_SQ_02"));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1292));

		AddDialogHook("3CMLAKE_84_PEOPLE1", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_84_PEOPLE1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE_84_SQ_03_DLG_01", "F_3CMLAKE_84_SQ_03", "I'll go there", "Waiting it out is definitely the best"))
		{
			case 1:
				dialog.UnHideNPC("3CMLAKE_84_WORKBENCH3");
				dialog.HideNPC("3CMLAKE_84_WORKBENCH1");
				dialog.UnHideNPC("3CMLAKE_83_WORKBENCH2");
				dialog.HideNPC("3CMLAKE_83_WORKBENCH1");
				// Func/SCR_F_3CMLAKE_84_SQ_02_RESTART;
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

