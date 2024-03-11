//--- Melia Script -----------------------------------------------------------
// Burning Before Moving
//--- Description -----------------------------------------------------------
// Quest to Talk to Skirgaila.
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

[QuestScript(72110)]
public class Quest72110Script : QuestScript
{
	protected override void Load()
	{
		SetId(72110);
		SetName("Burning Before Moving");
		SetDescription("Talk to Skirgaila");

		AddPrerequisite(new LevelPrerequisite(333));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE261_SQ10"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15651));

		AddDialogHook("3CMLAKE_SKIRGAILA", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_SKIRGAILA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE261_SQ11_DLG01", "F_3CMLAKE261_SQ11", "Leave it to me.", "I'm afraid it's too difficult for me."))
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

		await dialog.Msg("3CMLAKE261_SQ11_DLG03");
		dialog.HideNPC("3CMLAKE_CART");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

