//--- Melia Script -----------------------------------------------------------
// Hot-blooded Simon Shaw (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Simon Shaw.
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

[QuestScript(17024)]
public class Quest17024Script : QuestScript
{
	protected override void Load()
	{
		SetId(17024);
		SetName("Hot-blooded Simon Shaw (3)");
		SetDescription("Talk to Simon Shaw");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FTOWER45_SQ_03_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(126));
		AddPrerequisite(new CompletedPrerequisite("FTOWER45_SQ_02"));

		AddObjective("kill0", "Kill 1 Bearkaras", new KillObjective(1, MonsterId.Boss_Bearkaras_Q3));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3150));

		AddDialogHook("FTOWER45_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER45_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER45_SQ_03_ST", "FTOWER45_SQ_03", "I'll defeat the Bearkaras for you ", "Better run away quickly"))
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

		await dialog.Msg("FTOWER45_SQ_03_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

