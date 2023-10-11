//--- Melia Script -----------------------------------------------------------
// Lost in the Forest (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Settler Izna.
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

[QuestScript(60080)]
public class Quest60080Script : QuestScript
{
	protected override void Load()
	{
		SetId(60080);
		SetName("Lost in the Forest (2)");
		SetDescription("Talk with Settler Izna");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAU16_SQ_04_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAU16_SQ_03"));

		AddObjective("kill0", "Kill 1 Woodspirit", new KillObjective(1, MonsterId.Boss_Woodspirit_Q1));

		AddReward(new ExpReward(1500, 1500));
		AddReward(new ItemReward("expCard1", 3));
		AddReward(new ItemReward("Vis", 13));

		AddDialogHook("SIAULIAI16_IZNA", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI16_IZNA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU16_SQ_04_01", "SIAU16_SQ_04", "I will come back soon", "I don't think it'll be much use"))
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

