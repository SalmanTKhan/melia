//--- Melia Script -----------------------------------------------------------
// Desperate Man
//--- Description -----------------------------------------------------------
// Quest to Investigate Carlyle's Mausoleum.
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

[QuestScript(80008)]
public class Quest80008Script : QuestScript
{
	protected override void Load()
	{
		SetId(80008);
		SetName("Desperate Man");
		SetDescription("Investigate Carlyle's Mausoleum");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CATACOMB_33_2_SQ_01_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_1_SQ_08"));

		AddObjective("kill0", "Kill 6 Green Stoulet(s) or Colitile(s)", new KillObjective(6, 58114, 58108));

		AddDialogHook("CATACOMB_33_2_GINTAS", "BeforeEnd", BeforeEnd);
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
		character.Quests.Start("CATACOMB_33_2_SQ_02");
	}
}

