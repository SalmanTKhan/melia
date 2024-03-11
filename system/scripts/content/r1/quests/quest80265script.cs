//--- Melia Script -----------------------------------------------------------
// Enemy Ambush (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Elder Ramunas.
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

[QuestScript(80265)]
public class Quest80265Script : QuestScript
{
	protected override void Load()
	{
		SetId(80265);
		SetName("Enemy Ambush (2)");
		SetDescription("Talk to Elder Ramunas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE_86_MQ_06_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(366));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_05"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19032));

		AddDialogHook("F_3CMLAKE_86_MQ_01_NPC_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_86_MQ_06_ST", "F_3CMLAKE_86_MQ_06", "Alright", "I'll think about it."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_86_MQ_06_AFST");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

