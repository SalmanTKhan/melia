//--- Melia Script -----------------------------------------------------------
// Marks of a legend(11)
//--- Description -----------------------------------------------------------
// Quest to Retrieve the Flechette.
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

[QuestScript(50235)]
public class Quest50235Script : QuestScript
{
	protected override void Load()
	{
		SetId(50235);
		SetName("Marks of a legend(11)");
		SetDescription("Retrieve the Flechette");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "BRACKEN43_3_SQ10_1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(313));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_3_SQ10"));

		AddObjective("kill0", "Kill 6 Romplenuka(s)", new KillObjective(6, MonsterId.Rompelnuka));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("BRACKEN433_SUBQ10_ITEM1", 1));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 129582));

		AddDialogHook("BRACKEN433_ARROW_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN433_ARROW_NPC", "BeforeEnd", BeforeEnd);
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

		ZoneServer.Instance.World.FindNPC("BRACKEN433_ARROW_NPC")?.PlayEffectLocal(character.Connection, "F_pc_making_finish_white", 1f, "BOT");
		dialog.HideNPC("BRACKEN433_ARROW_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

