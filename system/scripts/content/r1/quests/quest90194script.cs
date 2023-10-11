//--- Melia Script -----------------------------------------------------------
// First Aid(2)
//--- Description -----------------------------------------------------------
// Quest to Speak with Loremaster Ugnius.
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

[QuestScript(90194)]
public class Quest90194Script : QuestScript
{
	protected override void Load()
	{
		SetId(90194);
		SetName("First Aid(2)");
		SetDescription("Speak with Loremaster Ugnius");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "CORAL_44_1_SQ_70_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(327));
		AddPrerequisite(new CompletedPrerequisite("CORAL_44_1_SQ_60"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));

		AddDialogHook("CORAL_44_1_OLDMAN1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_1_MAN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_44_1_SQ_70_ST", "CORAL_44_1_SQ_70", "Trust me", "That's a difficult request. I'll need some time."))
		{
			case 1:
				await dialog.Msg("CORAL_44_1_SQ_70_AG");
				dialog.HideNPC("CORAL_44_1_OLDMAN1");
				dialog.UnHideNPC("CORAL_44_1_OLDMAN2");
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

