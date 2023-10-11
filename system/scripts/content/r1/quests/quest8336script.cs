//--- Melia Script -----------------------------------------------------------
// To Thorn Forest
//--- Description -----------------------------------------------------------
// Quest to Talk to the Owl Sculpture of Forecasts.
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

[QuestScript(8336)]
public class Quest8336Script : QuestScript
{
	protected override void Load()
	{
		SetId(8336);
		SetName("To Thorn Forest");
		SetDescription("Talk to the Owl Sculpture of Forecasts");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN18_MQ_30_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN18_BOSS_KILL"));

		AddDialogHook("KATYN18_MAIN_OWL_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN18_MQ_30_01", "KATYN18_MQ_30", "Open the door that leads to Thorn Forest", "Cancel"))
		{
			case 1:
				character.PlayEffectLocal("healing", 5);
				dialog.HideNPC("WARP_F_FKATYN_18");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

