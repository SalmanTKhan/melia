//--- Melia Script -----------------------------------------------------------
// Guardian Destructors (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Beholder.
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

[QuestScript(8383)]
public class Quest8383Script : QuestScript
{
	protected override void Load()
	{
		SetId(8383);
		SetName("Guardian Destructors (1)");
		SetDescription("Talk to the Beholder");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ZACHA4F_MQ_01_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(90));
		AddPrerequisite(new CompletedPrerequisite("ZACHA3F_MQ_04"));

		AddObjective("kill0", "Kill 6 Shtayim(s) or Vikaras(s)", new KillObjective(6, 41276, 401241));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 1800));

		AddDialogHook("ZACHA4F_MQ_01_BLACKMAN", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA4F_MQ", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA4F_MQ_01", "ZACHA4F_MQ_01", "I'll find where it is collapsing", "Ignore"))
		{
			case 1:
				dialog.HideNPC("ZACHA4F_MQ_01_BLACKMAN");
				await dialog.Msg("FadeOutIN/2000");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Stop the Guardians from destroying the Royal Mausoleum!");
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

