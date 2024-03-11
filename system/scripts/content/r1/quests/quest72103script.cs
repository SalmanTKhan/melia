//--- Melia Script -----------------------------------------------------------
// Crystal Stone at the Crossroad (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Beholder.
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

[QuestScript(72103)]
public class Quest72103Script : QuestScript
{
	protected override void Load()
	{
		SetId(72103);
		SetName("Crystal Stone at the Crossroad (1)");
		SetDescription("Talk to the Beholder");

		AddPrerequisite(new LevelPrerequisite(333));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE261_SQ03"));

		AddDialogHook("3CMLAKE_BLACKMAN01", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_BLACKMAN02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE261_SQ04_DLG01", "F_3CMLAKE261_SQ04", "I'll look into this.", "I need to rest for a bit."))
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

		await dialog.Msg("3CMLAKE261_SQ04_DLG03");
		dialog.HideNPC("3CMLAKE_BLACKMAN01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

