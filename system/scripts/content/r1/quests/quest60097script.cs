//--- Melia Script -----------------------------------------------------------
// Monster Colony (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Chaser Raitis.
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

[QuestScript(60097)]
public class Quest60097Script : QuestScript
{
	protected override void Load()
	{
		SetId(60097);
		SetName("Monster Colony (1)");
		SetDescription("Talk with Chaser Raitis");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 12 Jukopus(s) or Poisoned Kepa(s) or Pokubu(s) or Pokuborn(s)", new KillObjective(12, 58011, 400005, 58010, 58091));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("expCard1", 2));
		AddReward(new ItemReward("Vis", 104));

		AddDialogHook("SIAULIAI15RE_RIGITESS", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU15RE_SQ_04_01", "SIAU15RE_SQ_04", "I'll get rid of the nest", "I'd rather not have to do anything dangerous"))
		{
			case 1:
				await dialog.Msg("SIAU15RE_SQ_04_01_AG");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAU15RE_SQ_05");
	}
}

