//--- Melia Script -----------------------------------------------------------
// I Won't Give It To Them (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Carlyle's Spirit.
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

[QuestScript(80015)]
public class Quest80015Script : QuestScript
{
	protected override void Load()
	{
		SetId(80015);
		SetName("I Won't Give It To Them (1)");
		SetDescription("Talk to Carlyle's Spirit");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_2_SQ_07"));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1406));

		AddDialogHook("CATACOMB_33_2_KARLYLE", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_33_2_KARLYLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_33_2_SQ_08_start", "CATACOMB_33_2_SQ_08", "I'll try to find them", "The reason why the list of manor owners is here", "I will leave since I've done my task"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("CATACOMB_33_2_SQ_08_add");
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
		character.Quests.Start("CATACOMB_33_2_SQ_09");
	}
}

