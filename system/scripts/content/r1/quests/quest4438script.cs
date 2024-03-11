//--- Melia Script -----------------------------------------------------------
// Jonas' Medicine (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Medicine Dealer.
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

[QuestScript(4438)]
public class Quest4438Script : QuestScript
{
	protected override void Load()
	{
		SetId(4438);
		SetName("Jonas' Medicine (2)");
		SetDescription("Talk to the Medicine Dealer");

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("ROKAS24_QB_13"));

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("ROKAS24_QB_11_DRUG", 1));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("ROKAS_24_PHARMACIST", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_PHARMACIST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_QB_11_select1", "ROKAS24_QB_11", "I'll bring you the Canyon Metos", "I will get it later"))
		{
			case 1:
				dialog.UnHideNPC("ROKAS_24_FLORIJONAS2");
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

		await Task.Delay(1000);
		await dialog.Msg("ROKAS24_QB_11_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

