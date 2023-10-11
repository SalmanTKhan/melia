//--- Melia Script -----------------------------------------------------------
// Medicine
//--- Description -----------------------------------------------------------
// Quest to Talk to Villager Deailan.
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

[QuestScript(50174)]
public class Quest50174Script : QuestScript
{
	protected override void Load()
	{
		SetId(50174);
		SetName("Medicine");
		SetDescription("Talk to Villager Deailan");

		AddPrerequisite(new LevelPrerequisite(246));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 9102));

		AddDialogHook("TABLE72_PEAPLE3", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE72_PEAPLE3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_72_SQ10_startnpc1", "TABLELAND_72_SQ10", "I can gather the herbs for you.", "I'm sorry to hear that."))
		{
			case 1:
				await dialog.Msg("TABLELAND_72_SQ10_startnpc2");
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

		await dialog.Msg("TABLELAND_72_SQ10_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

