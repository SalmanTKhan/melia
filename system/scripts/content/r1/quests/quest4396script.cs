//--- Melia Script -----------------------------------------------------------
// An Endless Mission (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Alan.
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

[QuestScript(4396)]
public class Quest4396Script : QuestScript
{
	protected override void Load()
	{
		SetId(4396);
		SetName("An Endless Mission (2)");
		SetDescription("Talk to Soldier Alan");

		AddPrerequisite(new LevelPrerequisite(123));
		AddPrerequisite(new CompletedPrerequisite("THORN23_Q_4"));

		AddDialogHook("THORN23_ALAN", "BeforeStart", BeforeStart);
		AddDialogHook("THORN23_WALLACE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN23_Q_6_select1", "THORN23_Q_6", "Offer to deliver the report", "I'm not a new recruit"))
		{
			case 1:
				await dialog.Msg("THORN23_Q_6_startnpc01");
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

		await dialog.Msg("THORN23_Q_6_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

