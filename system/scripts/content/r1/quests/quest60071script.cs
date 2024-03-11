//--- Melia Script -----------------------------------------------------------
// The Journey Begins (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Settler Brophen.
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

[QuestScript(60071)]
public class Quest60071Script : QuestScript
{
	protected override void Load()
	{
		SetId(60071);
		SetName("The Journey Begins (2)");
		SetDescription("Talk with Settler Brophen");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAU16_MQ_02_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAU16_MQ_01"));

		AddObjective("kill0", "Kill 5 Kepa(s)", new KillObjective(5, MonsterId.Sec_Onion));

		AddReward(new ExpReward(1000, 1000));
		AddReward(new ItemReward("expCard1", 2));
		AddReward(new ItemReward("Vis", 13));

		AddDialogHook("SIAULIAI16_BROPHEN", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI16_BROPHEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU16_MQ_02_01", "SIAU16_MQ_02", "Monsters might come out", "There's no need to hurry"))
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

