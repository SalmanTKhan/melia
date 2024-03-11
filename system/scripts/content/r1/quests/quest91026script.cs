//--- Melia Script -----------------------------------------------------------
// Headstone on the South of Neryskus Grounds 
//--- Description -----------------------------------------------------------
// Quest to Find the Ancient Headstone and decipher it.
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

[QuestScript(91026)]
public class Quest91026Script : QuestScript
{
	protected override void Load()
	{
		SetId(91026);
		SetName("Headstone on the South of Neryskus Grounds ");
		SetDescription("Find the Ancient Headstone and decipher it");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "EP12_2_F_CASTLE_101_MQ03_2_TRACK_01", "None");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_2_F_CASTLE_101_MQ03"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("EP12_2_F_CASTLE_101_MQ03_2_STONE", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_2_F_CASTLE_101_MQ03_2_STONE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_2_F_CASTLE_101_MQ03_2_DLG_01", "EP12_2_F_CASTLE_101_MQ03_2", "I'll look for the headstone piece", "That's too difficult to do now"))
		{
			case 1:
				await dialog.Msg("EP12_2_F_CASTLE_101_MQ03_2_DLG_02");
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

