//--- Melia Script -----------------------------------------------------------
// Supply Removal Operation
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

[QuestScript(72108)]
public class Quest72108Script : QuestScript
{
	protected override void Load()
	{
		SetId(72108);
		SetName("Supply Removal Operation");
		SetDescription("Talk to Skirgaila");

		AddPrerequisite(new LevelPrerequisite(333));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE261_SQ01"));

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

		switch (await dialog.Select("3CMLAKE261_SQ09_DLG01", "F_3CMLAKE261_SQ09", "Alright", "Can you ask someone else to do it?"))
		{
			case 1:
				await dialog.Msg("3CMLAKE261_SQ09_DLG02");
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

		await dialog.Msg("3CMLAKE261_SQ09_DLG04");
		dialog.HideNPC("3CMLAKE_SACK");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

