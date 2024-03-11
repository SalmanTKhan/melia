//--- Melia Script -----------------------------------------------------------
// What Giltine Left Behind
//--- Description -----------------------------------------------------------
// Quest to Meet Goddess Laima in the Laima's Sanctuary.
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

[QuestScript(90501)]
public class Quest90501Script : QuestScript
{
	protected override void Load()
	{
		SetId(90501);
		SetName("What Giltine Left Behind");
		SetDescription("Meet Goddess Laima in the Laima's Sanctuary");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "GIVEHOLYTHING_TRACK_01", "None");

		AddPrerequisite(new LevelPrerequisite(458));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_5_MQ_07"));

		AddReward(new ItemReward("Relic_Guilty", 1));
		AddReward(new ItemReward("misc_Ectonite_NoTrade", 1));
		AddReward(new ItemReward("Gem_Relic_Cyan_L_004", 1));
		AddReward(new ItemReward("Gem_Relic_Magenta_L_004", 1));

		AddDialogHook("NPC_LITTLEGIRL_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("GIVEHOLYTHING_Q_1_DLG1", "GIVEHOLYTHING_Q_1", "Close your eyes", "Keep your eyes wide open"))
		{
			case 1:
				// Func/GIVEHOLYTHING_MOVE_ZONE;
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

