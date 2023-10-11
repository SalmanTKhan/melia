//--- Melia Script -----------------------------------------------------------
// The Legwyn Family's Tragedy (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the spirit of Gailus Legwyn.
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

[QuestScript(60063)]
public class Quest60063Script : QuestScript
{
	protected override void Load()
	{
		SetId(60063);
		SetName("The Legwyn Family's Tragedy (2)");
		SetDescription("Talk to the spirit of Gailus Legwyn");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM313_SQ_06_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM313_SQ_05"));

		AddObjective("kill0", "Kill 1 Kartas Hunter Dullahan", new KillObjective(1, MonsterId.Boss_Durahan_Q1));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1700));

		AddDialogHook("PILGRIM313_GALIUS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM313_GALIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM313_SQ_06_01", "PILGRIM313_SQ_06", "I will be with him", "Tell him to wait a bit longer"))
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
}

