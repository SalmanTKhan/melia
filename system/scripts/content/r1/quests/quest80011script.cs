//--- Melia Script -----------------------------------------------------------
// The Leader of the Order
//--- Description -----------------------------------------------------------
// Quest to Talk to the spirit of the Believer.
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

[QuestScript(80011)]
public class Quest80011Script : QuestScript
{
	protected override void Load()
	{
		SetId(80011);
		SetName("The Leader of the Order");
		SetDescription("Talk to the spirit of the Believer");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_2_SQ_03"));

		AddDialogHook("CATACOMB_33_2_GHOST", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_33_2_MARGIRIS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_33_2_SQ_04_start", "CATACOMB_33_2_SQ_04", "I am looking for the corrupted acts of the Order", "Let's ignore since it seems you are seeing some hallucinations"))
		{
			case 1:
				await dialog.Msg("CATACOMB_33_2_SQ_04_agree");
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
		character.Quests.Start("CATACOMB_33_2_SQ_05");
	}
}

