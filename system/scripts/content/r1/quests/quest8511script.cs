//--- Melia Script -----------------------------------------------------------
// Church Gate (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Vaidutis.
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

[QuestScript(8511)]
public class Quest8511Script : QuestScript
{
	protected override void Load()
	{
		SetId(8511);
		SetName("Church Gate (2)");
		SetDescription("Talk to Follower Vaidutis");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CHAPLE576_MQ_04_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(44));
		AddPrerequisite(new CompletedPrerequisite("CHAPLE576_MQ_01"));

		AddObjective("kill0", "Kill 1 Mummyghast", new KillObjective(1, MonsterId.Boss_Mummyghast));

		AddReward(new ExpReward(118188, 118188));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 21));
		AddReward(new ItemReward("Vis", 6600));

		AddDialogHook("CHAPEL_VIRGINIJA", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPLE576_MQ_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE576_MQ_02_01", "CHAPLE576_MQ_02", "I'll open the gate", "I'll wait a little bit"))
		{
			case 1:
				dialog.HideNPC("CHAPEL576_GELE574");
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
		character.Quests.Start("CHAPLE576_MQ_04_1");
	}
}

