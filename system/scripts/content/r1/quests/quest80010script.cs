//--- Melia Script -----------------------------------------------------------
// Those Brothers
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Gintas.
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

[QuestScript(80010)]
public class Quest80010Script : QuestScript
{
	protected override void Load()
	{
		SetId(80010);
		SetName("Those Brothers");
		SetDescription("Talk to Believer Gintas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_2_SQ_02"));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1406));

		AddDialogHook("CATACOMB_33_2_GINTAS", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_33_2_GHOST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_33_2_SQ_03_start", "CATACOMB_33_2_SQ_03", "I will do it if it is for the Order", "Decline"))
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

