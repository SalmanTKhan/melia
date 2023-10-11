//--- Melia Script -----------------------------------------------------------
// Petrifying Frost Forecast (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Royal Army Guard Retia.
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

[QuestScript(8804)]
public class Quest8804Script : QuestScript
{
	protected override void Load()
	{
		SetId(8804);
		SetName("Petrifying Frost Forecast (3)");
		SetDescription("Talk to Royal Army Guard Retia");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FLASH59_SQ_05_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(184));
		AddPrerequisite(new CompletedPrerequisite("FLASH59_SQ_04"));

		AddObjective("kill0", "Kill 1 Sparnashorn", new KillObjective(1, MonsterId.Boss_Sparnashorn_2));

		AddReward(new ExpReward(2093340, 2093340));
		AddReward(new ItemReward("expCard9", 2));
		AddReward(new ItemReward("Vis", 62744));

		AddDialogHook("FLASH59_RETIA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH59_RETIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH59_SQ_05_01", "FLASH59_SQ_05", "I will defeat it", "Tell him that you will wait until it gets safe"))
		{
			case 1:
				await dialog.Msg("FLASH59_SQ_05_01_01");
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

		await dialog.Msg("FLASH59_SQ_05_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

