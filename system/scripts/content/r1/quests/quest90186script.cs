//--- Melia Script -----------------------------------------------------------
// The Great Problem-Solver (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Baron Munchausen.
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

[QuestScript(90186)]
public class Quest90186Script : QuestScript
{
	protected override void Load()
	{
		SetId(90186);
		SetName("The Great Problem-Solver (4)");
		SetDescription("Talk to Baron Munchausen");

		AddPrerequisite(new LevelPrerequisite(290));
		AddPrerequisite(new CompletedPrerequisite("LOWLV_BOASTER_SQ_30"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("misc_ore17", 1));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("LOWLV_BOASTER_MUENCHHAUSEN", "BeforeStart", BeforeStart);
		AddDialogHook("LOWLV_BOASTER_MUENCHHAUSEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LOWLV_BOASTER_SQ_40_ST", "LOWLV_BOASTER_SQ_40"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("LOWLV_BOASTER_SQ_40_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

