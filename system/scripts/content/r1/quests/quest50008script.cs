//--- Melia Script -----------------------------------------------------------
// Gytis' Worry
//--- Description -----------------------------------------------------------
// Quest to Talk to Gytis.
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

[QuestScript(50008)]
public class Quest50008Script : QuestScript
{
	protected override void Load()
	{
		SetId(50008);
		SetName("Gytis' Worry");
		SetDescription("Talk to Gytis");

		AddPrerequisite(new LevelPrerequisite(69));

		AddDialogHook("SIAULIAI_50_1_SQ_GYTIS", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FIREMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_50_1_SQ_010_select01", "SIAULIAI_50_1_SQ_010", "I'll help", "About the monsters", "You're busy so just ignore "))
		{
			case 1:
				await dialog.Msg("SIAULIAI_50_1_SQ_010_starnpc02");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("SIAULIAI_50_1_SQ_010_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("SIAULIAI_50_1_SQ_010_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_50_1_SQ_020");
	}
}

