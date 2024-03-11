//--- Melia Script -----------------------------------------------------------
// Honey-eating Biteregina
//--- Description -----------------------------------------------------------
// Quest to Check the mead storage boxes.
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

[QuestScript(16110)]
public class Quest16110Script : QuestScript
{
	protected override void Load()
	{
		SetId(16110);
		SetName("Honey-eating Biteregina");
		SetDescription("Check the mead storage boxes");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAULIAI_46_4_SQ_02_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(160));
		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_4_MQ_04"));

		AddObjective("kill0", "Kill 1 Biteregina", new KillObjective(1, MonsterId.Boss_BiteRegina_Q4));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 4800));

		AddDialogHook("SIAULIAI_46_4_MEADBOX", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}
}

