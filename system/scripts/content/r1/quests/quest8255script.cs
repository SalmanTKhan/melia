//--- Melia Script -----------------------------------------------------------
// Recycling (2)
//--- Description -----------------------------------------------------------
// Quest to Read the epitaph.
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

[QuestScript(8255)]
public class Quest8255Script : QuestScript
{
	protected override void Load()
	{
		SetId(8255);
		SetName("Recycling (2)");
		SetDescription("Read the epitaph");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA1F_MQ_05_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(81));
		AddPrerequisite(new CompletedPrerequisite("ZACHA1F_MQ_04"));

		AddObjective("kill0", "Kill 1 Achat", new KillObjective(1, MonsterId.Boss_Achat));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("R_BRC03_105", 1));
		AddReward(new ItemReward("Vis", 1620));

		AddDialogHook("ZACHA1F_MQ_05_NPC", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA1F_MQ_05_select01", "ZACHA1F_MQ_05", "Let's look for Achat", "Let's postpone"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

