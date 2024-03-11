//--- Melia Script -----------------------------------------------------------
// Dead of the Dead (2)
//--- Description -----------------------------------------------------------
// Quest to Try making the rubbing of the tablet at Vseio Cliffs.
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

[QuestScript(40540)]
public class Quest40540Script : QuestScript
{
	protected override void Load()
	{
		SetId(40540);
		SetName("Dead of the Dead (2)");
		SetDescription("Try making the rubbing of the tablet at Vseio Cliffs");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "REMAINS37_1_SQ_060_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(168));
		AddPrerequisite(new CompletedPrerequisite("REMAINS37_1_SQ_050"));
		AddPrerequisite(new ItemPrerequisite("REMAINS37_1_SQ_050_ITEM_1", 4));

		AddObjective("kill0", "Kill 13 Wendigo Shaman(s) or Wendigo Searcher(s) or Temple Slave Assassin(s)", new KillObjective(13, 57620, 57622, 57596));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5040));

		AddDialogHook("REMAINS37_1_MT05", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_1_MT05", "BeforeEnd", BeforeEnd);
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Exclaimation, "The rubbing didn't turn out alright.{nl}Please tell this to Adrijus", 5);
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

