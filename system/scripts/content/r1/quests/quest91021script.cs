//--- Melia Script -----------------------------------------------------------
// Inevitable Fate
//--- Description -----------------------------------------------------------
// Quest to Meet Goddess Laima at the end of the Path of Desition.
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

[QuestScript(91021)]
public class Quest91021Script : QuestScript
{
	protected override void Load()
	{
		SetId(91021);
		SetName("Inevitable Fate");
		SetDescription("Meet Goddess Laima at the end of the Path of Desition");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "EP12_2_F_DACPITAL_104_MQ01_TRACK_01", "None");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_FINALE_05"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));

		AddDialogHook("EP12_FINALE_RAIMA02", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_FINALE_RAIMA02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_2_F_DACPITAL_104_MQ01_DLG_01", "EP12_2_F_DACPITAL_104_MQ01", "Ask about the Ritual", "I am not ready yet"))
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

		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP12_2_F_CASTLE_101_MQ01");
	}
}

