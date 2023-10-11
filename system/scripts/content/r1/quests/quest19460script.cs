//--- Melia Script -----------------------------------------------------------
// Insatiable Hunger (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Liliya.
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

[QuestScript(19460)]
public class Quest19460Script : QuestScript
{
	protected override void Load()
	{
		SetId(19460);
		SetName("Insatiable Hunger (3)");
		SetDescription("Talk to Pilgrim Liliya");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM46_SQ_030_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(121));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM46_SQ_020"));

		AddObjective("kill0", "Kill 1 Carnivore", new KillObjective(1, MonsterId.Boss_Carnivore_Q1));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("NECK02_115", 1));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("PILGRIM46_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM46_NPC01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

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

