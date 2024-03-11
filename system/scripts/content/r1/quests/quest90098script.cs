//--- Melia Script -----------------------------------------------------------
// Inject the supplement
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Lina.
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

[QuestScript(90098)]
public class Quest90098Script : QuestScript
{
	protected override void Load()
	{
		SetId(90098);
		SetName("Inject the supplement");
		SetDescription("Talk to Kupole Lina");

		AddPrerequisite(new LevelPrerequisite(289));
		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_3_SQ_30"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12138));

		AddDialogHook("MAPLE_25_3_LINA", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE_25_3_SQ_40_ST", "MAPLE_25_3_SQ_40", "I'll go there", "About the work Lina has been doing", "Give me some time to prepare"))
		{
			case 1:
				await dialog.Msg("MAPLE_25_3_SQ_40_AG");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("MAPLE_25_3_SQ_40_ADD");
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("MAPLE_25_3_SQ_50");
	}
}

