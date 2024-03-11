//--- Melia Script -----------------------------------------------------------
// The Final Battle (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Commander Byle.
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

[QuestScript(72212)]
public class Quest72212Script : QuestScript
{
	protected override void Load()
	{
		SetId(72212);
		SetName("The Final Battle (4)");
		SetDescription("Talk to Resistance Commander Byle");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "STARTOWER_92_MQ_40_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(386));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_92_MQ_30"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));
		AddReward(new ItemReward("Vis", 20458));

		AddDialogHook("D_STARTOWER_92_RESISTANCE_LEADER_BAYL_03", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_92_MQ_30_TRIGGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_92_MQ_40_DLG1", "STARTOWER_92_MQ_40", "Alright", "Sorry, I need more time."))
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The road to the Observatory has been cleared!{nl}Go to the First Observatory and defeat Ignas!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("STARTOWER_92_MQ_50");
	}
}

