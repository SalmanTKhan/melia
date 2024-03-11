//--- Melia Script -----------------------------------------------------------
// Unwelcome Guest from the Forest
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Rikke.
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

[QuestScript(8601)]
public class Quest8601Script : QuestScript
{
	protected override void Load()
	{
		SetId(8601);
		SetName("Unwelcome Guest from the Forest");
		SetDescription("Talk to Watcher Rikke");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "GELE574_MQ_01_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(35));

		AddObjective("kill0", "Kill 1 Biteregina", new KillObjective(1, MonsterId.Boss_BiteRegina_Q3));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 490));

		AddDialogHook("GELE574_REIKE", "BeforeStart", BeforeStart);
		AddDialogHook("GELE574_REIKE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GELE574_MQ_01_01", "GELE574_MQ_01", "It's easy", "It looks dangerous"))
		{
			case 1:
				dialog.UnHideNPC("GELE574_MQ_01");
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

		await dialog.Msg("GELE574_MQ_01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

