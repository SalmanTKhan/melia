//--- Melia Script -----------------------------------------------------------
// Mysterious Slate (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Knight Commander Uska.
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

[QuestScript(20051)]
public class Quest20051Script : QuestScript
{
	protected override void Load()
	{
		SetId(20051);
		SetName("Mysterious Slate (2)");
		SetDescription("Talk to Knight Commander Uska");
		SetTrack(QuestStatus.Progress, QuestStatus.Progress, "CMINE6_TO_KATYN7_2_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(20));
		AddPrerequisite(new CompletedPrerequisite("CMINE6_TO_KATYN7_1"));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));

		AddDialogHook("KLAPEDA_USKA", "BeforeStart", BeforeStart);
		AddDialogHook("KLAPEDA_USKA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CMINE6_TO_KATYN7_2_select1", "CMINE6_TO_KATYN7_2", "I'll go visit the Bokor Master", "I'll think about it little more"))
		{
			case 1:
				// Func/CMINE6_TO_KATYN7_2_FUNC;
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

		await dialog.Msg("CMINE6_TO_KATYN7_2_succ1");
		await dialog.Msg("CMINE6_TO_KATYN7_2_succ2");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You have survived a formidable experience!{nl}Speak with the Wings of Vaivora NPC to record your experience and collect your reward!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CMINE6_TO_KATYN7_3");
	}
}

