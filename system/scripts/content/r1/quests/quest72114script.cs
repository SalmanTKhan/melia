//--- Melia Script -----------------------------------------------------------
// Where is the Recruit? (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Abraomas.
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

[QuestScript(72114)]
public class Quest72114Script : QuestScript
{
	protected override void Load()
	{
		SetId(72114);
		SetName("Where is the Recruit? (3)");
		SetDescription("Talk to Abraomas");

		AddPrerequisite(new LevelPrerequisite(333));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE261_SQ14"));

		AddDialogHook("3CMLAKE_ABRAOMAS", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_LEONARDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE261_SQ15_DLG01", "F_3CMLAKE261_SQ15", "Alright", "I'm afraid I can't."))
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

		await dialog.Msg("3CMLAKE261_SQ15_DLG03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

