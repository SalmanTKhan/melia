//--- Melia Script -----------------------------------------------------------
// Suspicious Believers
//--- Description -----------------------------------------------------------
// Quest to Talk to Bokor Juta.
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

[QuestScript(80007)]
public class Quest80007Script : QuestScript
{
	protected override void Load()
	{
		SetId(80007);
		SetName("Suspicious Believers");
		SetDescription("Talk to Bokor Juta");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_1_SQ_07"));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1330));

		AddDialogHook("CATACOMB_33_1_JUTA2", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_33_1_SIGIS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_33_1_SQ_08_start", "CATACOMB_33_1_SQ_08", "I'll deliver it for you", "I can only help so much"))
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

