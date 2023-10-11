//--- Melia Script -----------------------------------------------------------
// Kupole Rescue Mission (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Medena.
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

[QuestScript(80131)]
public class Quest80131Script : QuestScript
{
	protected override void Load()
	{
		SetId(80131);
		SetName("Kupole Rescue Mission (2)");
		SetDescription("Talk to Kupole Medena");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "LIMESTONE_52_2_MQ_6_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(291));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_2_MQ_5"));

		AddObjective("kill0", "Kill 1 Intensive Spirit Device2", new KillObjective(1, MonsterId.Soul_Gathering_Mchn_2));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12222));

		AddDialogHook("LIMESTONECAVE_52_2_MEDENA_AI", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_2_MQ_6_start", "LIMESTONE_52_2_MQ_6", "Let's destroy them.", "I'm not so sure about this, sorry."))
		{
			case 1:
				// Func/LIMESTONE_52_2_REENTER_RUN;
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

