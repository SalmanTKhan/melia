//--- Melia Script -----------------------------------------------------------
// To the Laboratory
//--- Description -----------------------------------------------------------
// Quest to Talk to Necromancer Drasius.
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

[QuestScript(8754)]
public class Quest8754Script : QuestScript
{
	protected override void Load()
	{
		SetId(8754);
		SetName("To the Laboratory");
		SetDescription("Talk to Necromancer Drasius");

		AddPrerequisite(new LevelPrerequisite(99));
		AddPrerequisite(new CompletedPrerequisite("REMAIN38_SQ02"), new CompletedPrerequisite("REMAIN38_SQ03"), new CompletedPrerequisite("REMAIN38_SQ04"));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1980));

		AddDialogHook("REMAIN38_SQ_DRASIUS", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN38_SQ06", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN38_SQ05_01", "REMAIN38_SQ05", "I will try", "Finish it yourself."))
		{
			case 1:
				// Func/REMAIN38_SQ05_MON_CREATE;
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


		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("REMAIN38_SQ06");
	}
}

