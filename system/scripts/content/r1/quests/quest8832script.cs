//--- Melia Script -----------------------------------------------------------
// Great Escape Portal (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Chronomancer Sabina.
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

[QuestScript(8832)]
public class Quest8832Script : QuestScript
{
	protected override void Load()
	{
		SetId(8832);
		SetName("Great Escape Portal (3)");
		SetDescription("Talk to Chronomancer Sabina");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FLASH61_SQ_11_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(190));
		AddPrerequisite(new CompletedPrerequisite("FLASH61_SQ_10"));

		AddObjective("kill0", "Kill 1 Lepus", new KillObjective(1, MonsterId.Boss_Lepus_Q1));

		AddReward(new ExpReward(2379430, 2379430));
		AddReward(new ItemReward("expCard10", 2));
		AddReward(new ItemReward("Vis", 47120));

		AddDialogHook("FLASH61_SABINA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH61_SABINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH61_SQ_11_01", "FLASH61_SQ_11", "I'm ready", "Wait for a while"))
		{
			case 1:
				await dialog.Msg("FLASH61_SQ_11_02");
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

		await dialog.Msg("FLASH61_SQ_11_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

