//--- Melia Script -----------------------------------------------------------
// Path of the Healer [Cleric Advancement](2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Centurion Master.
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

[QuestScript(17320)]
public class Quest17320Script : QuestScript
{
	protected override void Load()
	{
		SetId(17320);
		SetName("Path of the Healer [Cleric Advancement](2)");
		SetDescription("Talk to the Centurion Master");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_CLERIC4_2_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("JOB_CLERIC4_1"));

		AddObjective("kill0", "Kill 1 Biteregina", new KillObjective(1, MonsterId.Boss_BiteRegina_J1));

		AddDialogHook("JOB_CENT4_NPC", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_CLERIC4_2_ST", "JOB_CLERIC4_2", "I'll collect Nocotias", "I'll just go back"))
		{
			case 1:
				await Task.Delay(10000);
				dialog.UnHideNPC("JOB_CLERIC_GRASS");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

