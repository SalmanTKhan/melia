//--- Melia Script -----------------------------------------------------------
// Removing Barrier (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Ausrine.
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

[QuestScript(91207)]
public class Quest91207Script : QuestScript
{
	protected override void Load()
	{
		SetId(91207);
		SetName("Removing Barrier (1)");
		SetDescription("Talk to Goddess Ausrine");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_2_D_NICOPOLIS_2_MQ_3_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(493));
		AddPrerequisite(new CompletedPrerequisite("EP15_2_D_NICOPOLIS_2_MQ_2"));

		AddObjective("kill0", "Kill 1 Statue", new KillObjective(1, MonsterId.Boss_Roze_Stones_Statue_Curse_Obj));
		AddObjective("kill1", "Kill 20 Masma(s)", new KillObjective(20, MonsterId.Ep15_2_Masma));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("EP15_2_D_NICO_2_AUSIRINE_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_2_D_NICOPOLIS_2_MQ_3_DLG1", "EP15_2_D_NICOPOLIS_2_MQ_3", "I will come back after destroying the stone statue.", "Ask for help."))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

