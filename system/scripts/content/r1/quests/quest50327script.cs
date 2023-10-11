//--- Melia Script -----------------------------------------------------------
// Into a Dogfight
//--- Description -----------------------------------------------------------
// Quest to Talk to the Monk.
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

[QuestScript(50327)]
public class Quest50327Script : QuestScript
{
	protected override void Load()
	{
		SetId(50327);
		SetName("Into a Dogfight");
		SetDescription("Talk to the Monk");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WTREES22_2_SQ2_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(348));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_2_SQ1"));

		AddDialogHook("WTREES22_2_SUBQ1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES22_2_SUBQ1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_2_SUBQ2_START1", "WTREES22_2_SQ2", "I'll help you", "It's too difficult. I refuse."))
		{
			case 1:
				await dialog.Msg("WTREES22_2_SUBQ2_AGG1");
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The road to Narvas Temple is filled with demons fighting amongst themselves.{nl}As the monk said, burn the hunter demons' base to lure them out.");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("WTREES22_2_SQ3");
	}
}

