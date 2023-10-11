//--- Melia Script -----------------------------------------------------------
// Spirit Interrogation
//--- Description -----------------------------------------------------------
// Quest to Talk to Margiris.
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

[QuestScript(80012)]
public class Quest80012Script : QuestScript
{
	protected override void Load()
	{
		SetId(80012);
		SetName("Spirit Interrogation");
		SetDescription("Talk to Margiris");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_2_SQ_04"));

		AddDialogHook("CATACOMB_33_2_MARGIRIS", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_33_2_KARLYLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_33_2_SQ_05_start", "CATACOMB_33_2_SQ_05", "I will go to Carlyle", "I will suspend it"))
		{
			case 1:
				dialog.UnHideNPC("CATACOMB_33_2_KARLYLE");
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
		character.Quests.Start("CATACOMB_33_2_SQ_06");
	}
}

