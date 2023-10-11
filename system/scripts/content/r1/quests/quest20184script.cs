//--- Melia Script -----------------------------------------------------------
// Trick of the Demon (2)
//--- Description -----------------------------------------------------------
// Quest to Protect the Royal Mausoleum Stone Lantern.
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

[QuestScript(20184)]
public class Quest20184Script : QuestScript
{
	protected override void Load()
	{
		SetId(20184);
		SetName("Trick of the Demon (2)");
		SetDescription("Protect the Royal Mausoleum Stone Lantern");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA2F_MQ_03_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(84));
		AddPrerequisite(new CompletedPrerequisite("ZACHA2F_MQ_02"));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("ZACHARIEL33_GUARDIAN2", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHARIEL33_GUARDIAN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA2F_MQ_03_03", "ZACHA2F_MQ_03", "I follow the whereabouts of Rexipher", "Don't chase"))
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Exclaimation, "Follow Rexipher and go to Royal Mausoleum 3F!", 7);
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

