//--- Melia Script -----------------------------------------------------------
// Sealed Soul (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sealed Stone.
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

[QuestScript(17008)]
public class Quest17008Script : QuestScript
{
	protected override void Load()
	{
		SetId(17008);
		SetName("Sealed Soul (1)");
		SetDescription("Talk to the Sealed Stone");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FTOWER42_SQ_02_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(116));

		AddObjective("kill0", "Kill 1 Golem", new KillObjective(1, MonsterId.Boss_Golem_Q1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 2784));

		AddDialogHook("FTOWER42_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER42_SQ_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER42_SQ_02_ST", "FTOWER42_SQ_02", "Defeat the monitors", "It's annoying so just leave"))
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

		await dialog.Msg("FTOWER42_SQ_02_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER42_SQ_03");
	}
}

