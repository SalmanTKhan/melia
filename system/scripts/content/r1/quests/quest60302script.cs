//--- Melia Script -----------------------------------------------------------
// The Fugitive's Dream (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Velad.
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

[QuestScript(60302)]
public class Quest60302Script : QuestScript
{
	protected override void Load()
	{
		SetId(60302);
		SetName("The Fugitive's Dream (5)");
		SetDescription("Talk to Kupole Velad");

		AddPrerequisite(new LevelPrerequisite(378));
		AddPrerequisite(new CompletedPrerequisite("DCAPITAL107_SQ_4"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 20952));

		AddDialogHook("DCAPITAL107_BLAD_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL107_GRISIA_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL107_SQ_5_1", "DCAPITAL107_SQ_5", "Removing the trap", "Leave it be."))
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

		await dialog.Msg("DCAPITAL107_SQ_5_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

