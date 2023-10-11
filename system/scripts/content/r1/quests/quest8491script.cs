//--- Melia Script -----------------------------------------------------------
// Mage Tower 4th Floor (4)
//--- Description -----------------------------------------------------------
// Quest to Find the Magic Control Room.
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

[QuestScript(8491)]
public class Quest8491Script : QuestScript
{
	protected override void Load()
	{
		SetId(8491);
		SetName("Mage Tower 4th Floor (4)");
		SetDescription("Find the Magic Control Room");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FTOWER44_MQ_04_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(123));
		AddPrerequisite(new CompletedPrerequisite("FTOWER44_MQ_03"));

		AddObjective("kill0", "Kill 5 Minivern(s)", new KillObjective(5, MonsterId.Minivern));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 3075));

		AddDialogHook("FTOWER44_MQ_04_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER44_GRITA_REMAIN", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("FTOWER44_MQ_04_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER44_MQ_05");
	}
}

