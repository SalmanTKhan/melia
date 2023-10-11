//--- Melia Script -----------------------------------------------------------
// The identity of the gigantic transformed plant
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Raeli.
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

[QuestScript(16500)]
public class Quest16500Script : QuestScript
{
	protected override void Load()
	{
		SetId(16500);
		SetName("The identity of the gigantic transformed plant");
		SetDescription("Talk with Priest Raeli");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "SIAULIAI_46_2_SQ_01_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Golem", new KillObjective(1, MonsterId.Boss_Golem));

		AddReward(new ExpReward(418668, 418668));
		AddReward(new ItemReward("expCard9", 2));
		AddReward(new ItemReward("Vis", 11088891));

		AddDialogHook("SIAULIAI_46_2_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_2_MQ01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAULIAI_46_2_SQ_02_select", "SIAULIAI_46_2_SQ_01", "I will check it out", "Don't mind it"))
		{
			case 1:
				await dialog.Msg("SIAULIAI_46_2_SQ_02_start_prog");
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

		await dialog.Msg("SIAULIAI_46_2_SQ_02_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

