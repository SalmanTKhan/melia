//--- Melia Script -----------------------------------------------------------
// They Hid Her (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Serija.
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

[QuestScript(80154)]
public class Quest80154Script : QuestScript
{
	protected override void Load()
	{
		SetId(80154);
		SetName("They Hid Her (4)");
		SetDescription("Talk to Kupole Serija");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "LIMESTONE_52_4_MQ_6_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(298));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_4_MQ_5"));

		AddObjective("kill0", "Kill 10 Green Flamme Archer(s) or Green Flamag(s)", new KillObjective(10, 58473, 58472));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 12516));

		AddDialogHook("LIMESTONECAVE_52_4_SERIJA", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_4_MQ_6_start", "LIMESTONE_52_4_MQ_6", "It will be hard to do it in these conditions.", "I am not ready yet"))
		{
			case 1:
				// Func/LIMESTONE_52_4_REENTER_RUN;
				character.AddonMessage(AddonMessage.SHOW_QUEST_SEL_DLG, null, this.QuestId);
				await dialog.Msg("LIMESTONE_52_4_MQ_6_ST01");
				await dialog.Msg("메데나와 함께 여신을 구하겠다고 한다");
				await dialog.Msg("LIMESTONE_52_4_MQ_6_AG01");
				await dialog.Msg("LIMESTONE_52_4_MQ_6_AG02");
				await dialog.Msg("LIMESTONE_52_4_MQ_6_AG03");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

