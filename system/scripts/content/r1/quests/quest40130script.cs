//--- Melia Script -----------------------------------------------------------
// Needing the Nutritious Tonic (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Stepas.
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

[QuestScript(40130)]
public class Quest40130Script : QuestScript
{
	protected override void Load()
	{
		SetId(40130);
		SetName("Needing the Nutritious Tonic (2)");
		SetDescription("Talk to Soldier Stepas");

		AddPrerequisite(new LevelPrerequisite(84));
		AddPrerequisite(new CompletedPrerequisite("FARM47_4_SQ_060"));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("FARM47_STEPAS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_DALIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM47_4_SQ_070_ST", "FARM47_4_SQ_070", "That much, I can help", "I'll get going now"))
		{
			case 1:
				await dialog.Msg("FARM47_4_SQ_070_AC");
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

		await dialog.Msg("FARM47_4_SQ_070_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FARM47_4_SQ_080");
	}
}

