//--- Melia Script -----------------------------------------------------------
// Rescue Edmundas (1)
//--- Description -----------------------------------------------------------
// Quest to Follow Traveling Merchant Rose to the Novaha Annex.
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

[QuestScript(50125)]
public class Quest50125Script : QuestScript
{
	protected override void Load()
	{
		SetId(50125);
		SetName("Rescue Edmundas (1)");
		SetDescription("Follow Traveling Merchant Rose to the Novaha Annex");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_1_MQ050"));

		AddReward(new ExpReward(126630, 126630));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 735));

		AddDialogHook("ABBEY642_ROZE01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY642_ROZE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_2_MQ010_startnpc01", "ABBAY_64_2_MQ010", "It's dangerous, stay here", "Let's rest for a while first"))
		{
			case 1:
				dialog.UnHideNPC("ABBEY642_EDMONDAS");
				await dialog.Msg("ABBAY_64_2_MQ010_startnpc02");
				// Func/ABBEY642_NPC_UNHIDE;
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

