//--- Melia Script -----------------------------------------------------------
// Suspiciously Secretive (11)
//--- Description -----------------------------------------------------------
// Quest to Talk to Agailla Flurry Apparition.
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

[QuestScript(50366)]
public class Quest50366Script : QuestScript
{
	protected override void Load()
	{
		SetId(50366);
		SetName("Suspiciously Secretive (11)");
		SetDescription("Talk to Agailla Flurry Apparition");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ABBEY22_5_SQ12_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(357));
		AddPrerequisite(new CompletedPrerequisite("ABBEY22_5_SQ11"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 18207));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("ABBEY225_FLURRY3", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY225_SUBQ1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY22_5_SUBQ12_START1", "ABBEY22_5_SQ12", "Go to Monk Aistis.", "I'm getting nervous..."))
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

		dialog.HideNPC("ABBEY225_DECEPTION_HAUBERK");
		dialog.HideNPC("ABBEY225_SUBQ1_NPC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

