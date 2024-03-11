//--- Melia Script -----------------------------------------------------------
// The Corrupted Lake (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Elder Aloizard.
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

[QuestScript(90019)]
public class Quest90019Script : QuestScript
{
	protected override void Load()
	{
		SetId(90019);
		SetName("The Corrupted Lake (2)");
		SetDescription("Talk to Elder Aloizard");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_83_MQ_01"));

		AddDialogHook("3CMLAKE_83_OLDMAN2", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_83_OLDMAN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE_83_MQ_06_DLG_01", "F_3CMLAKE_83_MQ_06"))
		{
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
}

