//--- Melia Script -----------------------------------------------------------
// New Researcher's Favor (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the New Researcher in the Royal Mausoleum.
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

[QuestScript(4428)]
public class Quest4428Script : QuestScript
{
	protected override void Load()
	{
		SetId(4428);
		SetName("New Researcher's Favor (1)");
		SetDescription("Talk to the New Researcher in the Royal Mausoleum");

		AddPrerequisite(new LevelPrerequisite(58));

		AddObjective("collect0", "Collect 9 Lost Research Document(s)", new CollectItemObjective("ROKAS24_QB_1_PENITEM", 9));
		AddDrop("ROKAS24_QB_1_PENITEM", 8f, 401181, 401101, 401061);

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("ROKAS_24_NEWCOMER", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_NEWCOMER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_QB_1_select1", "ROKAS24_QB_1", "I'll find it for you", "About the Gate of the Great King", "Cheer up"))
		{
			case 1:
				await dialog.Msg("ROKAS24_QB_1_AG");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("ROKAS24_QB_1_add");
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS24_QB_2");
	}
}

