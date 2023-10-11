//--- Melia Script -----------------------------------------------------------
// Historian Kepeck (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Mercenary Mirta.
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

[QuestScript(4442)]
public class Quest4442Script : QuestScript
{
	protected override void Load()
	{
		SetId(4442);
		SetName("Historian Kepeck (2)");
		SetDescription("Talk to Mercenary Mirta");

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("ROKAS24_DIALOG2"));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Drug_SP1_Q", 30));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("ROKAS24_MIRTA", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_KEFEK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_QB_15_select01", "ROKAS24_QB_15", "I will bring the supplies back", "Tell her to take some rest and look for them slowly"))
		{
			case 1:
				await dialog.Msg("ROKAS24_QB_15_start01");
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

		await dialog.Msg("ROKAS24_QB_15_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS24_KILL3");
	}
}

