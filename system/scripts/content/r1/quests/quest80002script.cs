//--- Melia Script -----------------------------------------------------------
// The Picky Grave Keeper
//--- Description -----------------------------------------------------------
// Quest to Talk to Bokor Juta.
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

[QuestScript(80002)]
public class Quest80002Script : QuestScript
{
	protected override void Load()
	{
		SetId(80002);
		SetName("The Picky Grave Keeper");
		SetDescription("Talk to Bokor Juta");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_1_SQ_02"));

		AddDialogHook("CATACOMB_33_1_JUTA", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_33_1_SIGIS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_33_1_SQ_03_start", "CATACOMB_33_1_SQ_03", "I'll search for the grave keeper", "About the holy relic of the goddess", "It'll be better to untie it yourself"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("CATACOMB_33_1_SQ_03_add");
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
		character.Quests.Start("CATACOMB_33_1_SQ_04");
	}
}

