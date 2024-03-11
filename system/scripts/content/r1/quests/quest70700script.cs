//--- Melia Script -----------------------------------------------------------
// The Amnesiac Soul
//--- Description -----------------------------------------------------------
// Quest to Talk to the Soul of Hayatin.
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

[QuestScript(70700)]
public class Quest70700Script : QuestScript
{
	protected override void Load()
	{
		SetId(70700);
		SetName("The Amnesiac Soul");
		SetDescription("Talk to the Soul of Hayatin");

		AddPrerequisite(new LevelPrerequisite(278));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 11398));

		AddDialogHook("BRACKEN421_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN421_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN421_SQ_01_start", "BRACKEN42_1_SQ01", "Tell me how and I will do it.", "Decline"))
		{
			case 1:
				await dialog.Msg("BRACKEN421_SQ_01_add");
				// Func/SCR_BRACKEN421_SQ_01_S;
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

		await dialog.Msg("BRACKEN421_SQ_01_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

