//--- Melia Script -----------------------------------------------------------
// Aid Recovery
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hunter.
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

[QuestScript(8071)]
public class Quest8071Script : QuestScript
{
	protected override void Load()
	{
		SetId(8071);
		SetName("Aid Recovery");
		SetDescription("Talk to the Hunter");

		AddPrerequisite(new LevelPrerequisite(10));

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("HAND01_117", 1));
		AddReward(new ItemReward("FOOT01_117", 1));
		AddReward(new ItemReward("Vis", 130));

		AddDialogHook("SIAULIAIOUT_HUNTER", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_HUNTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SOUT_Q_05_1", "SOUT_Q_05", "I'll help retrieve the relief supplies", "Decline"))
		{
			case 1:
				dialog.UnHideNPC("SIAULIAIOUT_119_2");
				dialog.UnHideNPC("SIAULIAIOUT_119_3");
				dialog.UnHideNPC("SIAULIAIOUT_119_4");
				dialog.UnHideNPC("SIAULIAIOUT_119_5");
				dialog.UnHideNPC("SIAULIAIOUT_119_6");
				dialog.UnHideNPC("SIAULIAIOUT_119_7");
				dialog.UnHideNPC("SIAULIAIOUT_119_8");
				dialog.UnHideNPC("SIAULIAIOUT_119_9");
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

		await dialog.Msg("SOUT_Q_05_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

