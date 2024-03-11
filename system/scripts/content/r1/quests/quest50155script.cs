//--- Melia Script -----------------------------------------------------------
// Contact
//--- Description -----------------------------------------------------------
// Quest to Talk to Assistant Commander Talon.
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

[QuestScript(50155)]
public class Quest50155Script : QuestScript
{
	protected override void Load()
	{
		SetId(50155);
		SetName("Contact");
		SetDescription("Talk to Assistant Commander Talon");

		AddPrerequisite(new LevelPrerequisite(238));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_70_SQ9"));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 8568));

		AddDialogHook("TABLE70_CAPTIN1_3", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE70_CAPTIN1_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_70_SQ10_startnpc01", "TABLELAND_70_SQ10", "I'll relay the situation to Knight Commander Uska.", "I can't think of a way to do that."))
		{
			case 1:
				await dialog.Msg("TABLELAND_70_SQ10_startnpc02");
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

		await dialog.Msg("TABLELAND_70_SQ10_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

