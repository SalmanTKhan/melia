//--- Melia Script -----------------------------------------------------------
// Where the Sun Shines [Pyromancer Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Put the pot of the sun at Ramstis Ridge.
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

[QuestScript(1133)]
public class Quest1133Script : QuestScript
{
	protected override void Load()
	{
		SetId(1133);
		SetName("Where the Sun Shines [Pyromancer Advancement] (2)");
		SetDescription("Put the pot of the sun at Ramstis Ridge");

		AddPrerequisite(new LevelPrerequisite(85));
		AddPrerequisite(new CompletedPrerequisite("JOB_PYROMANCER3_1"));

		AddDialogHook("MASTER_FIREMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("JOB_PYROMANCER3_2_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Put the Sun Essence on the spot that Chapparition was guarding");
	}
}

