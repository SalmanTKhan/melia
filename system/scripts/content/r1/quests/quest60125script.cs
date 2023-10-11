//--- Melia Script -----------------------------------------------------------
// Unidentified Package (2)
//--- Description -----------------------------------------------------------
// Quest to Use the Unidentified Packages to see their effect.
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

[QuestScript(60125)]
public class Quest60125Script : QuestScript
{
	protected override void Load()
	{
		SetId(60125);
		SetName("Unidentified Package (2)");
		SetDescription("Use the Unidentified Packages to see their effect");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PRISON621_SQ_03"));

		AddReward(new ExpReward(8058, 8058));
		AddReward(new ItemReward("expCard2", 3));
		AddReward(new ItemReward("Vis", 221));

		AddDialogHook("PRISON621_DARAMAUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

