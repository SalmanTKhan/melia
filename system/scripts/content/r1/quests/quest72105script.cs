//--- Melia Script -----------------------------------------------------------
// Crystal Stone at the Crossroad (3)
//--- Description -----------------------------------------------------------
// Quest to Absorb magic from the Crystal Stone in Zibukas Crossroad.
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

[QuestScript(72105)]
public class Quest72105Script : QuestScript
{
	protected override void Load()
	{
		SetId(72105);
		SetName("Crystal Stone at the Crossroad (3)");
		SetDescription("Absorb magic from the Crystal Stone in Zibukas Crossroad");

		AddPrerequisite(new LevelPrerequisite(333));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE261_SQ05"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15651));

		AddDialogHook("3CMLAKE261_SQ04_LINK_STONE01", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_BLACKMAN02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("3CMLAKE261_SQ06_DLG02");
		dialog.HideNPC("3CMLAKE261_SQ04_LINK_STONE01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

