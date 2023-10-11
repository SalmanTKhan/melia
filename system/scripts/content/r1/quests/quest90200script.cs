//--- Melia Script -----------------------------------------------------------
// The Suspicious Demons
//--- Description -----------------------------------------------------------
// Quest to Speak with Revelator Nichi.
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

[QuestScript(90200)]
public class Quest90200Script : QuestScript
{
	protected override void Load()
	{
		SetId(90200);
		SetName("The Suspicious Demons");
		SetDescription("Speak with Revelator Nichi");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "CORAL_44_2_SQ_10_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(331));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_1_SQ_100"));

		AddObjective("kill0", "Kill 16 Nimrah Lancer(s) or Nimrah Duke(s) or Nimrah Soldier(s) or Varle Hench(s) or Varle Gunner(s)", new KillObjective(16, 58824, 58879, 58825, 58827, 58826));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));

		AddDialogHook("CORAL_44_2_MAN2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_2_SQ_20_TRIGGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_2_SQ_10_ST", "CORAL_44_2_SQ_10", "Talk about what happened in Zeteor Coast. ", "No"))
		{
			case 1:
				await dialog.Msg("CORAL_44_2_SQ_10_AG");
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

