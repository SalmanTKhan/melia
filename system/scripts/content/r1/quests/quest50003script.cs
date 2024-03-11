//--- Melia Script -----------------------------------------------------------
// To Kvailas Forest
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Saule.
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

[QuestScript(50003)]
public class Quest50003Script : QuestScript
{
	protected override void Load()
	{
		SetId(50003);
		SetName("To Kvailas Forest");
		SetDescription("Talk to Goddess Saule");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "HUEVILLAGE_58_4_MQ09_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(64));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_4_MQ08"));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));

		AddDialogHook("HUEVILLAGE_58_4_SAULE_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_4_MQ09_BLACK_MAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

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

