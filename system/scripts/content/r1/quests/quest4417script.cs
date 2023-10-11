//--- Melia Script -----------------------------------------------------------
// Missing Researcher (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Airine.
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

[QuestScript(4417)]
public class Quest4417Script : QuestScript
{
	protected override void Load()
	{
		SetId(4417);
		SetName("Missing Researcher (3)");
		SetDescription("Talk to Airine");

		AddPrerequisite(new LevelPrerequisite(67));
		AddPrerequisite(new CompletedPrerequisite("ROKAS27_QB_4"));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1273));

		AddDialogHook("ROKAS27_AIRINE", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS27_AIRINE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS27_QB_5_select1", "ROKAS27_QB_5", "Inform her to hold on until the barrier devices are deactivated", "Inform her that Dezic will help"))
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

		dialog.HideNPC("ROKAS27_AIRINE_EFFECT");
		await dialog.Msg("ROKAS27_QB_5_succ1");
		// Func/SCR_ROKAS_2_DEAD;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

