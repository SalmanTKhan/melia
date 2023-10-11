//--- Melia Script -----------------------------------------------------------
// A Dead End (4)
//--- Description -----------------------------------------------------------
// Quest to Talk with Member Alina.
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

[QuestScript(60050)]
public class Quest60050Script : QuestScript
{
	protected override void Load()
	{
		SetId(60050);
		SetName("A Dead End (4)");
		SetDescription("Talk with Member Alina");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PILGRIM311_SQ_08_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM311_SQ_07"));

		AddObjective("kill0", "Kill 1 Chaser Werewolf", new KillObjective(1, MonsterId.Boss_Werewolf_Q3));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1640));

		AddDialogHook("PILGRIM311_ALINA_02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM311_IRMANTAS_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM311_SQ_08_01", "PILGRIM311_SQ_08", "We're almost there. Cheer up. ", "Let's rest a bit more"))
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

