//--- Melia Script -----------------------------------------------------------
// Missing Researcher (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Archaeologist Dezic.
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

[QuestScript(4416)]
public class Quest4416Script : QuestScript
{
	protected override void Load()
	{
		SetId(4416);
		SetName("Missing Researcher (2)");
		SetDescription("Talk to Archaeologist Dezic");

		AddPrerequisite(new LevelPrerequisite(67));
		AddPrerequisite(new CompletedPrerequisite("ROKAS27_QB_1"));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1273));

		AddDialogHook("ROKAS27_DESIG_02", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS27_AIRINE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS27_QB_4_select1", "ROKAS27_QB_4", "I'll save Airine", "Call the mercenary"))
		{
			case 1:
				dialog.UnHideNPC("ROKAS27_AIRINE_EFFECT");
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

