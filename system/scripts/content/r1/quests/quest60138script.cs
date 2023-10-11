//--- Melia Script -----------------------------------------------------------
// A Deeper Place (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Irma.
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

[QuestScript(60138)]
public class Quest60138Script : QuestScript
{
	protected override void Load()
	{
		SetId(60138);
		SetName("A Deeper Place (3)");
		SetDescription("Talk with Priest Irma");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PRISON623_MQ_03_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PRISON623_MQ_02"));

		AddObjective("kill0", "Kill 1 Denoptic", new KillObjective(1, MonsterId.Boss_Denoptic_Q2));

		AddReward(new ExpReward(40290, 40290));
		AddReward(new ItemReward("expCard2", 3));
		AddReward(new ItemReward("Vis", 350));

		AddDialogHook("PRISON623_IRMA_01", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON623_IRMA_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON623_MQ_03_01", "PRISON623_MQ_03", "I'll go there", "I'm going to get some rest and go"))
		{
			case 1:
				dialog.UnHideNPC("PRISON623_MQ_03_NPC");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
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
}

