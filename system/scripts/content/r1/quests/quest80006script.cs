//--- Melia Script -----------------------------------------------------------
// The Wrong Faith
//--- Description -----------------------------------------------------------
// Quest to Talk to Bokor Juta.
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

[QuestScript(80006)]
public class Quest80006Script : QuestScript
{
	protected override void Load()
	{
		SetId(80006);
		SetName("The Wrong Faith");
		SetDescription("Talk to Bokor Juta");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CATACOMB_33_1_SQ_07_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_1_SQ_06"));

		AddObjective("kill0", "Kill 1 Abomination", new KillObjective(1, MonsterId.Boss_Abomination_Q1));

		AddReward(new ExpReward(274320, 274320));
		AddReward(new ItemReward("expCard5", 6));
		AddReward(new ItemReward("Vis", 1330));

		AddDialogHook("CATACOMB_33_1_JUTA", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_33_1_JUTA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_33_1_SQ_07_start", "CATACOMB_33_1_SQ_07", "I will go there first", "Give me some time to prepare"))
		{
			case 1:
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_33_1_SQ_08");
	}
}

