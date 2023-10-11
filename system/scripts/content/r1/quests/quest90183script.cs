//--- Melia Script -----------------------------------------------------------
// The Great Problem-Solver (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Baron Munchausen.
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

[QuestScript(90183)]
public class Quest90183Script : QuestScript
{
	protected override void Load()
	{
		SetId(90183);
		SetName("The Great Problem-Solver (1)");
		SetDescription("Talk to Baron Munchausen");

		AddPrerequisite(new LevelPrerequisite(290));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("misc_ore17", 2));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("LOWLV_BOASTER_MUENCHHAUSEN", "BeforeStart", BeforeStart);
		AddDialogHook("LOWLV_BOASTER_MUENCHHAUSEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LOWLV_BOASTER_SQ_10_ST", "LOWLV_BOASTER_SQ_10", "What do you mean?", "La-la-la-la-la~"))
		{
			case 1:
				await dialog.Msg("LOWLV_BOASTER_SQ_10_AG");
				dialog.UnHideNPC("LOWLV_BOASTER_SQ_10_BOX");
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

		await dialog.Msg("LOWLV_BOASTER_SQ_10_SU");
		dialog.HideNPC("LOWLV_BOASTER_SQ_10_BOX");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

