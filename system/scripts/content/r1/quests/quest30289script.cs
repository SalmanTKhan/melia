//--- Melia Script -----------------------------------------------------------
// Demon Treaty (4)
//--- Description -----------------------------------------------------------
// Quest to Retrieve the Demon Treaty in Tamsus Ikeitimas.
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

[QuestScript(30289)]
public class Quest30289Script : QuestScript
{
	protected override void Load()
	{
		SetId(30289);
		SetName("Demon Treaty (4)");
		SetDescription("Retrieve the Demon Treaty in Tamsus Ikeitimas");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WTREES_21_1_SQ_6_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(325));
		AddPrerequisite(new CompletedPrerequisite("WTREES_21_1_SQ_5"));

		AddObjective("kill0", "Kill 1 Cerberus", new KillObjective(1, MonsterId.Boss_Kerberos_Q2));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("WTREES_21_1_SQ_6_ITEM", 1));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15275));

		AddDialogHook("WTREES_21_1_OBJ_4", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES_21_1_OBJ_4", "BeforeEnd", BeforeEnd);
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The Demon Treaty is now in your hands.{nl}Return to the site of the treaty seal.");
		ZoneServer.Instance.World.FindNPC("WTREES_21_1_OBJ_4")?.PlayEffectLocal(character.Connection, "F_pc_making_finish_red", 2.0f, "MID");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

